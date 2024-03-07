using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkedDisable : MonoBehaviour
{
    public GameObject DisableOBJ;
    public string Handtag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == Handtag)
        {
            Disable();
        }
    }

    public void Disable()
    {
        PhotonView pv = DisableOBJ.GetComponent<PhotonView>();
        if (pv != null)
        {
            pv.RPC("SetActiveStateRPC", RpcTarget.All, false); 
        }
    }
}
