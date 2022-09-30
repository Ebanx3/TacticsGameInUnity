using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class ConnectionPhoton : MonoBehaviourPunCallbacks
{

    GameObject gameManager;
    public GameObject mainSceneManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        mainSceneManager = GameObject.Find("MainSceneManager");
        connectToMasterServer();
    }

    public void connectToMasterServer()
    {
        //Contemplar sistema de version para  que no se puedan conectar quienes tengan una version vieja
        PhotonNetwork.GameVersion = "0.1";
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting to server");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        gameManager.GetComponent<GameManager>().connectedToMasterServer = true;
        mainSceneManager.GetComponent<MainSceneManager>().ChangeConnectionState(true);
        Debug.Log("Connected to server");
        // SceneManager.LoadScene(1);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        mainSceneManager.GetComponent<MainSceneManager>().ChangeConnectionState(false);
        Debug.Log("Disconnected from server");
        //Implmementar funciones si se desconecta
    }
}
