using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    [Header("Set this to the gameObject you want to Enable")]
    public GameObject ObjectToEnable;

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(EnableObjectWithDelay());
    }

    private IEnumerator EnableObjectWithDelay()
    {
        yield return new WaitForSeconds(.19f); // Wait for 0 seconds
        ObjectToEnable.SetActive(true); // Enable the game object after the delay
    }
}
