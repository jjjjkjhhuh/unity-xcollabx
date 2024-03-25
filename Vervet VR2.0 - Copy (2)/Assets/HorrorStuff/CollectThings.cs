using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectThings : MonoBehaviour
{
    public GameObject thing;
    public AudioSource PickUpSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTag"))
        {
            thing.SetActive(false);
            PickUpSound.Play();
        }
    }
}
