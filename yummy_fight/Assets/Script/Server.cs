using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class Server : MonoBehaviourPunCallbacks,IInRoomCallbacks
{
    public TMP_Text statusText;
    public GameObject LoginPanel;
    public TMP_InputField playerNameInput;

    public GameObject ConnectingPanel;
    public GameObject LobbyPanel;

    private const int MaxPlayerPerRoom = 2;


    // Start is called before the first frame update
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

    }
    void Start()
    {
        statusText.enabled = false;
        LoginPanel.SetActive(true);
        ConnectingPanel.SetActive(false);
        LobbyPanel.SetActive(false);
    }

    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ConnectToPhotonServer() //LoginButtonで呼ぶ
    {
        if (!PhotonNetwork.IsConnected) //サーバーに接続していたら
        {
            string playerName = playerNameInput.text;
            if (!string.IsNullOrEmpty(playerName))
            {
                PhotonNetwork.LocalPlayer.NickName = playerName;
                PhotonNetwork.ConnectUsingSettings();
                ConnectingPanel.SetActive(true);
                LoginPanel.SetActive(false);
            }
        }
        else { }
    }

    public void JoinRandomRoom() //StartButtonで呼ぶ
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("マスターに接続しました");
        LobbyPanel.SetActive(true);
        ConnectingPanel.SetActive(false);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("ルームを作成します。");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayerPerRoom });
    }

    public override void OnJoinedRoom() //ルームに入ったら呼ばれる
    {
        Debug.Log(PhotonNetwork.NickName + "joined to" + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("ルームに参加しました");
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        if (playerCount != MaxPlayerPerRoom)
        {
            statusText.enabled = true;
            statusText.text = "waiting player...";
        }
        else
        {
            statusText.text = "対戦相手が揃いました。バトルシーンに移動します。";
        }
        //PhotonNetwork.LoadLevel("SampleScene"); //シーンをロード
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayerPerRoom)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;

                statusText.text = "対戦相手が揃いました。バトルシーンに移動します。";
                PhotonNetwork.LoadLevel("SampleScene");
            }
        }
    }
    /*void CreateAndJoinRoom()
    {
        //自動で作られるルームの設定
        string roomName = "Room" + Random.Range(0, 10000); //ルーム名
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 2;　//ルームの定員
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }*/
}
