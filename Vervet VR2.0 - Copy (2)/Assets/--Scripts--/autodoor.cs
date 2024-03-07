using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autodoor : MonoBehaviour
{
    public GameObject OpenDoor;
    public GameObject CloseDoor;
    public GameObject OGDoor;

    Vector3 startPosition;
    Vector3 closestartPosition;

    void Start()
    {
        startPosition = OpenDoor.transform.position;
        closestartPosition = CloseDoor.transform.position;
    }


    void OnTriggerEnter()
    {
        OpenDoor.SetActive(true);
        OGDoor.SetActive(false);
        CloseDoor.SetActive(false);
    }

    void OnTriggerExit()
    {
        OpenDoor.SetActive(false);
        CloseDoor.SetActive(true);
        OpenDoor.transform.position = startPosition;
        CloseDoor.transform.position = closestartPosition;
    }
}