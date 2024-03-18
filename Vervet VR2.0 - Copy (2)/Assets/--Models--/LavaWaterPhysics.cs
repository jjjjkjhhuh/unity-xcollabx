using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaWaterPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        rb.useGravity = false;
    }
    void OnTriggerExit()
    {
        rb.useGravity = true;
    }
    public Rigidbody rb;
}
