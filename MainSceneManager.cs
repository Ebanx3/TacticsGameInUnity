using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    GameObject gameManager;
    public GameObject connectionManager;
    ConnectionPhoton connectionPhoton;
    RoomsManager roomsManager;
    public Sprite connectedIcon;
    public Sprite notConnectedIcon;
    public Button connectButton;
    public bool connected;
    public TextMeshProUGUI connectText;
    bool tryingToReconnect = false;

    public TextMeshProUGUI infoText;

    public GameObject panel1vs1;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        connectionPhoton = connectionManager.GetComponent<ConnectionPhoton>();
        roomsManager = connectionManager.GetComponent<RoomsManager>();

    }

    public void TryReconnect()
    {
        if (!tryingToReconnect)
        {
            StartCoroutine(InfoConnection());
        }
    }

    IEnumerator InfoConnection()
    {
        tryingToReconnect = true;
        if (connected)
        {
            connectText.text = "You are already connected";
        }
        else
        {
            connectText.text = "Trying to reconnect";
            connectionPhoton.connectToMasterServer();
        }
        yield return new WaitForSecondsRealtime(3);
        connectText.text = "";
        tryingToReconnect = false;
    }

    public void ChangeConnectionState(bool state)
    {
        connected = state;
        if (connected)
        {
            connectButton.image.sprite = connectedIcon;
        }
        else
        {
            connectButton.image.sprite = notConnectedIcon;
        }
    }

    public void LookFor1v1Battle()
    {
        if (connected)
        {
            roomsManager.CreateRoom();
            panel1vs1.SetActive(true);
        }
        else
        {
            infoText.text = "You must be connected to do that";
        }
    }

    public void Cancel1v1Battle()
    {
        panel1vs1.SetActive(false);
        roomsManager.LeaveRoom();
    }
}
