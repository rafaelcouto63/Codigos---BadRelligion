using UnityEngine;
using UnityEngine.AI;
public class PathFindingWayPoints : MonoBehaviour 
{
	public  Transform[] waypoints;
	private int currentWayPoint;
	private NavMeshAgent agent;
	private Transform myTransform;

	public void Start() 
	{
		currentWayPoint = 0;
		agent = GetComponent<NavMeshAgent>();
		myTransform = GetComponent<Transform>();
		agent.SetDestination(waypoints[currentWayPoint].position);
	}

	public void FixedUpdate() 
	{
		Vector3 dir = waypoints[currentWayPoint].position - myTransform.position;

		if (dir.sqrMagnitude <= 1) 
		{
			currentWayPoint++;
			if (currentWayPoint >= waypoints.Length)
				currentWayPoint = 0;

			agent.SetDestination(waypoints[currentWayPoint].position);
		} 
	}
}
