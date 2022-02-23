using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Join Lobby
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    // Once joined, load scene  
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Game");
    }
}
