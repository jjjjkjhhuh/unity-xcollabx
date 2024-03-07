using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Putonenable : MonoBehaviour
{
    [PunRPC]
    public void SetActiveStateRPC_Enable(bool setActive)
    {
        gameObject.SetActive(setActive);
    }
}
