using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class unloadonstart : MonoBehaviour
{
    [Header("By taco, dont need to credit")]
    public List<GameObject> Unload;
    void Start()
    {
        foreach (var obj in Unload)
         obj.SetActive(false);
    }


    void Update()
    {
        
    }
}
