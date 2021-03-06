using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using Photon.Realtime;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{
    string gameVersion = "1";
    [SerializeField] private byte maxPlayersPerRoom = 4;

    [Tooltip("The Ui Panel to let the user enter name, connect and play")]
    [SerializeField] private GameObject controlPanel;

    [Tooltip("UI Label to inform the user that the connection is in progress")]
    [SerializeField] private GameObject progressLabel;

    /// <summary>
    /// Keep track of the current process. Since connection is asynchronous and is based on several callbacks from Photon,
    /// we need to keep track of this to properly adjust the behavior when we receive call back by Photon.
    /// Typically this is used for the OnConnectedToMaster() callback.
    /// </summary>
    bool isConnecting;      //To prevent player from automatically joing room after leaving it

    private void Awake()
    {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {

        progressLabel.SetActive(false);
        controlPanel.SetActive(true);

    }

    public void Connect()
    {
        #region Control Panel
        progressLabel.SetActive(true);
        controlPanel.SetActive(false);
        #endregion Control Panel

        #region Connect
        //we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected){
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            PhotonNetwork.JoinRandomRoom();
        }
        else {
            // #Critical, we must first and foremost connect to Photon Online Server.
            //isConnecting == true
            isConnecting = PhotonNetwork.ConnectUsingSettings();    //Connect and return it to isConnecting
            //isConnecting == false
            PhotonNetwork.GameVersion = gameVersion;
        }
        #endregion Connect
    }




    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() called by PUN");
        //The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
        if (isConnecting) { 
            PhotonNetwork.JoinRandomRoom();
            isConnecting = false;
        }
        //else callback OnJoinRandomFailed()

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed() was called by PUN.No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        PhotonNetwork.CreateRoom(null, new RoomOptions {  MaxPlayers = maxPlayersPerRoom});
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom() called by PUN. Now, this client is in a room.");


        if (PhotonNetwork.CurrentRoom.PlayerCount >= 1)
        {
            Debug.Log("Load Network Game Scene");
            PhotonNetwork.LoadLevel("Network Game Scene");
        }

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
        Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0}", cause);
    }
}
