using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class putondisableobj : MonoBehaviour
{
    [PunRPC]
    public void SetActiveStateRPC(bool setActive)
    {
        gameObject.SetActive(setActive);
    }
}
