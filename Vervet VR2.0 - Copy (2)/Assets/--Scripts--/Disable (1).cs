using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    [Header("Set this to the gameObject you want to Disable")]
    public GameObject ObjectToDisable;

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(DisableObjectWithDelay());
    }

    private IEnumerator DisableObjectWithDelay()
    {
        yield return new WaitForSeconds(.2f); // Wait for 0 seconds
        ObjectToDisable.SetActive(false); // Disable the game object after the delay
    }
}