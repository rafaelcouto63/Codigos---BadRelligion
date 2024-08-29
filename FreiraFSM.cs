using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FreiraFSM : MonoBehaviour
{
    public WaypointControl[] waypoints;
    public float patrolSpeed = 3.5f;
    public float followSpeed = 5f;
    public float followDistance = 10f;
    public float actionDistance = 2f;
    public Transform player;
    public GameObject actionObject; // O GameObject a ser habilitado
    public float actionDuration = 5f; // Tempo em segundos para manter o GameObject habilitado
    public AudioSource audioSource; // O AudioSource a ser habilitado
    public AudioSource followAudioSource; // O AudioSource para seguir o jogador
    public float audioDuration = 5f; // Tempo em segundos para manter o AudioSource habilitado
    public Transform moveToLocation; // Local para mover o jogador
    public float kinematicDuration = 5f; // Tempo em segundos para manter o isKinematic ativado
    public GameObject[] hearts; // Array de corações que representam a vida

    private int currentWayPoint;
    private NavMeshAgent agent;
    private Transform myTransform;
    private enum State { Patrolling, Following, Acting,MovingToPostActionLocation }
    private State currentState;
    private int currentHeartIndex = 0;
    public LayerMask wallLayer;
    public Transform postActionLocation; // Local para mover o inimigo após a ação


    public bool isFollowing = false;
    public bool isPatroling = false;
    public Animator animator;
    public string patrolAnimation = "Patrol";
    public string followAnimation = "Follow";

    void Start()
    {
        currentWayPoint = 0;
        agent = GetComponent<NavMeshAgent>();
        myTransform = GetComponent<Transform>();
        currentState = State.Patrolling;
        agent.speed = patrolSpeed;
        GoToNextPatrolPoint();
        isPatroling = true;
        animator.Play(patrolAnimation); // Iniciar com a animação de patrulha
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Patrolling:
                Patrol();
                break;
            case State.Following:
                FollowPlayer();
                break;
            case State.Acting:
                PerformAction();
                break;
            case State.MovingToPostActionLocation:
                MoveToPostActionLocation();
                break;    
        }
    }

    void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPatrolPoint();
        }

        // Verificar se o jogador está dentro da distância de perseguição
        if (Vector3.Distance(player.position, transform.position) < followDistance)
        {
        // Criar um Raycast da posição do inimigo até a posição do jogador
        RaycastHit hit;
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Debug.DrawRay(transform.position, directionToPlayer * followDistance, Color.red); // Visualizar o Raycast
        if (Physics.Raycast(transform.position, directionToPlayer, out hit, followDistance))
         {
            // Verificar se o Raycast atingiu um objeto com a camada Wall
            if (hit.collider.transform == player)
            {
                if (!Physics.Linecast(transform.position, player.position, wallLayer))
                {
                   currentState = State.Following;
                   isPatroling = false;
                   isFollowing = true;
                   agent.speed = followSpeed;
                   animator.Play(followAnimation); // Trocar para a animação de perseguição
                   if (followAudioSource != null && !followAudioSource.isPlaying)
                   {
                     followAudioSource.Play();
                   }
                }
            }
         }
        }
    }

    void FollowPlayer()
    {
        agent.destination = player.position;

        if (Vector3.Distance(player.position, transform.position) < actionDistance)
        {
            currentState = State.Acting;
            if (followAudioSource != null && followAudioSource.isPlaying)
            {
                followAudioSource.Stop();
            }
        }
        else if (Vector3.Distance(player.position, transform.position) >= followDistance)
        {
            currentState = State.Patrolling;
            isFollowing = false;
            isPatroling = true;
            agent.speed = patrolSpeed;
            GoToNextPatrolPoint();
            animator.Play(patrolAnimation); // Trocar para a animação de patrulha
            if (followAudioSource != null && followAudioSource.isPlaying)
            {
                followAudioSource.Stop();
            }
        }
    }

    void PerformAction()
    {
        // Habilitar o GameObject
        if (actionObject != null)
        {
            actionObject.SetActive(true);
            StartCoroutine(DisableActionObjectAfterTime(actionDuration));
        }

        // Habilitar o AudioSource
        if (audioSource != null)
        {
            audioSource.enabled = true;
            audioSource.Play();
            StartCoroutine(DisableAudioSourceAfterTime(audioDuration));
        }

        // Mover o jogador e ativar isKinematic
        if (moveToLocation != null && player != null)
        {
            player.position = moveToLocation.position;
            Rigidbody playerRb = player.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                playerRb.isKinematic = true;
                StartCoroutine(DisableKinematicAfterTime(playerRb, kinematicDuration));
            }
        }

        // Habilitar o próximo coração
        if (hearts != null && currentHeartIndex < hearts.Length)
        {
            hearts[currentHeartIndex].SetActive(true);
            currentHeartIndex++;
        }

        // Mudar para o estado de mover para a localização pós-ação
        currentState = State.MovingToPostActionLocation;
        agent.speed = patrolSpeed;
        animator.Play(patrolAnimation);
    }

    void MoveToPostActionLocation()
    {
        if (postActionLocation != null)
        {
            agent.destination = postActionLocation.position;

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                currentState = State.Patrolling;
                GoToNextPatrolPoint();
            }
        }
        else
        {
            currentState = State.Patrolling;
            GoToNextPatrolPoint();
        }
    }

    IEnumerator DisableActionObjectAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (actionObject != null)
        {
            actionObject.SetActive(false);
        }
    }

    IEnumerator DisableAudioSourceAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.enabled = false;
        }
    }

    IEnumerator DisableKinematicAfterTime(Rigidbody rb, float time)
    {
        yield return new WaitForSeconds(time);
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }

    void GoToNextPatrolPoint()
    {
        if (waypoints.Length == 0)
            return;

        agent.SetDestination(waypoints[currentWayPoint].myTransform.position);
        currentWayPoint = (currentWayPoint + 1) % waypoints.Length;
    }
}


