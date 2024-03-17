using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public Rigidbody GorillaPlayer;
    public int Force;
    public bool Debounce;
    
    void OnTriggerEnter()
    {
        {
            if (Debounce == false)
            {
                GorillaPlayer.AddForce(new Vector3(0, Force, 0), ForceMode.Impulse);
                StartCoroutine(DebounceEnum());
            }
        }
    }

    IEnumerator DebounceEnum()
    {
        Debounce = true;
        yield return new WaitForSeconds(0.2f);
        Debounce = false;
    }
}



