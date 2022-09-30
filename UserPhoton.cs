using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class UserPhoton : MonoBehaviour
{
    public string userName;
    public List<Character> character;

    GameObject turnManager;

    PhotonView PV;

    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
            turnManager = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TurnManager"), Vector3.zero, Quaternion.identity);
        }
    }



}
