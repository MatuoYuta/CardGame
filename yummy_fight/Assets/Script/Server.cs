using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Server : MonoBehaviourPunCallbacks
{
    public GameObject LoginPanel;
    public TMP_InputField playerNameInput;

    public GameObject ConnectingPanel;
    public GameObject LobbyPanel;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        LoginPanel.SetActive(true);
        ConnectingPanel.SetActive(false);
        LobbyPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConnectToPhotonServer() //LoginButton�ŌĂ�
    {
        if (!PhotonNetwork.IsConnected) //�T�[�o�[�ɐڑ����Ă�����
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

    public void JoinRandomRoom() //StartButton�ŌĂ�
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnConnectedToMaster()
    {
        LobbyPanel.SetActive(true);
        ConnectingPanel.SetActive(false);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateAndJoinRoom(); //���[�����Ȃ���Ύ������ē���
    }

    public override void OnJoinedRoom() //���[���ɓ�������Ă΂��
    {
        //Debug.Log(PhotonNetwork.NickName+ "joined to"+ PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("GameScene"); //�V�[�������[�h
    }

    void CreateAndJoinRoom()
    {
        //�����ō���郋�[���̐ݒ�
        string roomName = "Room" + Random.Range(0, 10000); //���[����
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 2;�@//���[���̒��
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }
}
