using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class CoinT : MonoBehaviourPunCallbacks
{
    private Animator CoinAnim;

    public int Coin;

    // Start is called before the first frame update
    void Start()
    {
        CoinAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinToss();
    }

    void CoinToss()
    {
        if (Input.GetKeyDown(KeyCode.Space)Å@&& PhotonNetwork.IsMasterClient)
        {
            Coin = Random.Range(0, 2);
            Debug.Log(Coin + "Ç≈Ç∑");
            CoinAnim.SetInteger("CoinCheck",Coin);
        }
    }

    public void OnAnimationEnd()
    {
        PhotonNetwork.LoadLevel("SampleScene");

    }
}
