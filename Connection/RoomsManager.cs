using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomsManager : MonoBehaviourPunCallbacks
{
    public int roomNumber = 0;
    public GameObject countDownText;
    private TextMeshProUGUI countDown;
    Player[] players;

    void Start()
    {
        countDown = countDownText.GetComponent<TextMeshProUGUI>();
    }

    public void CreateRoom()
    {
        PhotonNetwork.JoinOrCreateRoom("Room number :" + roomNumber, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
        Debug.Log("Connected to room " + roomNumber);

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Error trying to connect at room");
        CreateRoom();
    }

    public void JoinRoom()
    {
        // PhotonNetwork.JoinRoom("nameOfRoom");
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Joined at random room");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("You left room");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Error trying to join a room");
        CreateRoom();
    }

    IEnumerator StartCountDown()
    {

        countDownText.SetActive(true);
        countDown.text = "3";
        yield return new WaitForSecondsRealtime(1f);
        countDown.text = "2";
        yield return new WaitForSecondsRealtime(1f);
        countDown.text = "1";
        yield return new WaitForSecondsRealtime(1f);
        if (PhotonNetwork.IsMasterClient) PhotonNetwork.LoadLevel(4);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

        Debug.Log("Another player just joined this room");
        StartCoroutine(StartCountDown());
    }

    public override void OnJoinedRoom()
    {
        players = PhotonNetwork.PlayerList;
        if (players.Length > 1)
        {
            StartCoroutine(StartCountDown());
        }
    }

}
