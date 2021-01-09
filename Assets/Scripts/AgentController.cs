using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private int currentWaypointIndex;

    private void Start()
    {
        currentWaypointIndex = 0;
        //MoveToPosition(GetWayPointPosition(wayPoints[currentWayPointIndex]));
    }

    /*
    private void Update()
    {
        if (currentWayPointIndex < wayPoints.Length && gameObject.transform.position == GetWayPointPosition(wayPoints[currentWayPointIndex]))
        {
            currentWayPointIndex++;
            MoveToPosition(GetWayPointPosition(wayPoints[currentWayPointIndex]));
        }

    }
    */

    private void Update()
    {
        //Debug.Log("ENABLED");
        if(currentWaypointIndex < waypoints.Length)
        {
            //currentWaypointIndex++;
            MoveToPosition(GetWaypointPosition(waypoints[currentWaypointIndex]));
            enabled = false;
        }
        else
        {
            agent.isStopped = true;
        }
    }

    private void MoveToPosition(Vector3 newPosition)
    {
        agent.SetDestination(newPosition);
    }

    private Vector3 GetWaypointPosition(GameObject waypoint)
    {
        return waypoint.GetComponent<Transform>().position;
    }

    IEnumerator WaitToEnable(float time)
    {
        yield return new WaitForSeconds(time);
        enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentWaypointIndex < waypoints.Length && other.gameObject == waypoints[currentWaypointIndex])
        {
            currentWaypointIndex++;

            MoveToPosition(transform.position);
            //Debug.Log("TRIGGER ENTER");
            StartCoroutine(WaitToEnable(1f));
        }
    }
}
