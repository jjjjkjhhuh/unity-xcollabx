using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navtogveaway : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator1;
    public Animator animator2;
    public Animator animator3;
    public string tagString = "Chaser";
    public float playerDetectionRange = 10f;
    public List<Transform> randomRoamingPoints = new List<Transform>();
    public float roamingInterval = 5f;
    public float wanderSpeed = 4.5f;
    public float chaseSpeed = 7.5f;

    public float roamingAnimationSpeed = 0.75f;
    public float chasingAnimationSpeed = 1.80f;

    private void Start()
    {
        StartCoroutine(RoamToRandomPoint());
    }

    private void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(tagString);

        GameObject target = FindNearestPlayer(players);

        if (target != null)
        {
            SetChasingState();
            agent.destination = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        }
        else
        {
            SetRoamingState();

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                StartCoroutine(RoamToRandomPoint());
            }
        }
    }

    private void SetRoamingState()
    {
        agent.speed = wanderSpeed;
        animator1.speed = roamingAnimationSpeed;
        animator2.speed = roamingAnimationSpeed;
        animator3.speed = roamingAnimationSpeed;
    }

    private void SetChasingState()
    {
        agent.speed = chaseSpeed;
        animator1.speed = chasingAnimationSpeed;
        animator2.speed = chasingAnimationSpeed;
        animator3.speed = chasingAnimationSpeed;
    }

    private GameObject FindNearestPlayer(GameObject[] players)
    {
        GameObject nearestPlayer = null;
        float minDistance = float.MaxValue;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < minDistance && distance <= playerDetectionRange)
            {
                minDistance = distance;
                nearestPlayer = player;
            }
        }

        return nearestPlayer;
    }

    private IEnumerator RoamToRandomPoint()
    {
        if (randomRoamingPoints.Count > 0)
        {
            Transform randomDestination = randomRoamingPoints[UnityEngine.Random.Range(0, randomRoamingPoints.Count)];

            Vector3 directionToRoamPoint = randomDestination.position - transform.position;

            transform.rotation = Quaternion.LookRotation(-directionToRoamPoint);

            agent.destination = randomDestination.position;

            yield return new WaitForSeconds(roamingInterval);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerDetectionRange);
    }
}
