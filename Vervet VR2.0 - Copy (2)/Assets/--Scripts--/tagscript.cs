using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class tagscript : MonoBehaviourPunCallbacks
{
    [Header("Made by Whalemert")]

    [Header("Dependencies Stuff")]
    public PhotonView PhotonView;
    public Material TaggedMat;
    public Material DefualtMat;

    [Header("Tagged Stuff")]
    public bool IsTagged = false;
    public GameObject GorillaPlayer;
    public GameObject PlayerParticals;

    [Header("Tagger Stuff")]
    public bool IsTagger = false;
    public AudioSource TagSound;
    public AudioSource RoundStart;
    public string TagCollider;

    public void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            return;
        }
        else
        {
            if (other.CompareTag(TagCollider) && IsTagger == true)
            {
                photonView.RPC("Tagger", RpcTarget.All);
                IsTagger = true;
                Tagger();
                RoundStart.Play();
            }
        }
    }

    private void Update()
    {
        if (PhotonNetwork.CountOfPlayers == 1)
        {
            photonView.RPC("Tagger", RpcTarget.All);
        }
    }
    public void Start()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        else
        {
            if (IsTagger == true)
            {
                photonView.RPC("Tagger", RpcTarget.All);
                IsTagger = true;
                Tagger();
                RoundStart.Play();
            }
        }
    }

    [PunRPC]
    public void TagPlayer()
    {
        if (IsTagged == true)
        {
            GorillaPlayer.GetComponent<Renderer>().material = TaggedMat;
            TagSound.Play();
        }
    }

    [PunRPC]
    public void Tagger()
    {
        IsTagged = true;
        GorillaPlayer.GetComponent<Renderer>().material = TaggedMat;
    }
}