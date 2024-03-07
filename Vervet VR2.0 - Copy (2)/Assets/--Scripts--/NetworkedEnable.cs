using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using easyInputs;

public class NetworkedEnable: MonoBehaviour
{
    public GameObject EnableOBJ;
    public string Handtag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == Handtag)
        {
            Enable();
        }
    }

    public void Enable()
    {
        PhotonView pv = EnableOBJ.GetComponent<PhotonView>();
        if (pv != null)
        {
            pv.RPC("SetActiveStateRPC_Enable", RpcTarget.All, true); 
        }
    }
}