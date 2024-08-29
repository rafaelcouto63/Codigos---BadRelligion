using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    public Transform cameraTransform; // Referência à câmera
    public List<GameObject> collectedKeys; // Lista para armazenar as chaves coletadas

    public AudioClip[] footstepSounds; // Array de sons de passos
    private AudioSource audioSource; // AudioSource para reproduzir os sons

    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = (forward * moveVertical + right * moveHorizontal).normalized;
        rb.velocity = movement * speed;

        // Verifica se o jogador está se movendo
        if (movement.magnitude > 0 && !isMoving)
        {
            isMoving = true;
            StartCoroutine(PlayFootstepSounds());
        }
        else if (movement.magnitude == 0)
        {
            isMoving = false;
            StopCoroutine(PlayFootstepSounds());
        }

        if (Input.GetMouseButtonDown(0)) // Detecta clique do mouse
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Chave1") || hit.collider.CompareTag("Chave2"))
                {
                    collectedKeys.Add(hit.collider.gameObject); // Adiciona a chave à lista
                    hit.collider.gameObject.SetActive(false); // Desativa o objeto
                }
            }
        }
    }

    IEnumerator PlayFootstepSounds()
    {
        while (isMoving)
        {
            if (footstepSounds.Length > 0)
            {
                int randomIndex = Random.Range(0, footstepSounds.Length);
                audioSource.clip = footstepSounds[randomIndex];
                audioSource.Play();
            }
            yield return new WaitForSeconds(0.5f); // Intervalo entre os sons de passos
        }
    }
}
