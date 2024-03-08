using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BonkHammer : MonoBehaviour
{
    public PhotonView Photonview;
    public AudioSource BonkSound;

    void OnTriggerEnter(Collider other)
    {
        if (Photonview.IsMine)
        {
            return;
        }
        else
        {
            Photonview.RPC("PlayBonk", RpcTarget.All);
        }
    }

    [PunRPC]
    public void PlayBonk()
    {
        BonkSound.Play();
    }
}