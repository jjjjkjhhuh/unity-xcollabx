using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [Header("made by raidial! give credits pwease!!!\n")]

    [Header("NavMeshAgent Stuff")]
    public NavMeshAgent navmesh;
    public string Tag = "ChaseTag";
    public float chasespeed = 8;
    public float wanderspeed = 6;

    [Header("\nObjects")]
    public GameObject[] WanderPoints;
    public float radius = 10f;

    [Header("\nJumpscare Stuff")]
    public GameObject Jumpscare;
    public float JumpscareDuration = 1.7f;

    [Header("\nTeleporation Stuff")]
    public GameObject GorillaPlayer;
    public GameObject TeleporationArea;

    [Header("\nExtra! (Disable Wander Points mean that it will just wander with no points.)")]
    public AudioSource ChaseSound;
    public bool DisableWanderPoints;


    private int currentwanderpoint = 0;
    private Collider[] colliders;

    void Start()
    {
        SetNextWanderPoint();
    }

    void Update()
    {
        if (PhotonNetwork.IsConnected)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag(Tag);

            bool found = false;
            foreach (GameObject player in players)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= radius)
                {
                    found = true;
                    navmesh.SetDestination(player.transform.position);
                    navmesh.speed = chasespeed;
                    if (!ChaseSound.isPlaying)
                        ChaseSound.Play();
                    return;
                }
                else
                {
                    found = false;
                }
            }

            if (DisableWanderPoints && !found && !navmesh.pathPending && navmesh.remainingDistance < 0.5f)
            {
                if (!navmesh.hasPath || navmesh.remainingDistance <= navmesh.stoppingDistance)
                {
                    Vector3 randomdirection = Random.insideUnitSphere * radius;
                    randomdirection += transform.position;
                    NavMeshHit hit;
                    NavMesh.SamplePosition(randomdirection, out hit, radius, 1);
                    Vector3 final = hit.position;

                    navmesh.SetDestination(final);
                    navmesh.speed = wanderspeed;
                    if (ChaseSound.isPlaying)
                        ChaseSound.Stop();
                }
            }

            if (!DisableWanderPoints && !found && !navmesh.pathPending && navmesh.remainingDistance < 0.5f)
            {
                SetNextWanderPoint();
                if (ChaseSound.isPlaying)
                    ChaseSound.Stop();
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
            StartCoroutine(JumpscareOn());
    }

    IEnumerator JumpscareOn()
    {
        Collider[] allcolliders = GameObject.FindObjectsOfType<Collider>();
        foreach (Collider collider in allcolliders)
        {
            collider.enabled = false;
        }

        if (Jumpscare != null)
        {
            GorillaPlayer.GetComponent<Rigidbody>().isKinematic = true;
            colliders = GorillaPlayer.GetComponentsInChildren<Collider>();
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }
            GorillaPlayer.transform.position = TeleporationArea.transform.position;

            Jumpscare.SetActive(true);

            yield return new WaitForSeconds(JumpscareDuration);

            foreach (Collider collider in allcolliders)
            {
                collider.enabled = true;
            }

            foreach (Collider collider in colliders)
            {
                collider.enabled = true;
            }

            GorillaPlayer.GetComponent<Rigidbody>().isKinematic = false;

            Jumpscare.SetActive(false);
        }
    }

    void SetNextWanderPoint()
    {
        if (WanderPoints.Length > 0)
        {
            float closestdistance = Mathf.Infinity;
            int closestindex = 0;
            for (int i = 0; i < WanderPoints.Length; i++)
            {
                if (i == currentwanderpoint) continue;
                float distance = Vector3.Distance(transform.position, WanderPoints[i].transform.position);
                if (distance < closestdistance)
                {
                    closestdistance = distance;
                    closestindex = i;
                }
            }

            navmesh.SetDestination(WanderPoints[closestindex].transform.position);
            navmesh.speed = wanderspeed;
            if (ChaseSound.isPlaying)
                ChaseSound.Stop();

            currentwanderpoint = (currentwanderpoint + 1) % WanderPoints.Length;
        }
    }
}
