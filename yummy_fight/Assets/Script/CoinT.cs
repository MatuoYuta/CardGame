using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class CoinT : MonoBehaviourPunCallbacks
{
    private Animator CoinAnim;
    public Server Server;

    public int Coin;

    // Start is called before the first frame update
    void Start()
    {
        CoinAnim = GetComponent<Animator>();
        Server = GameObject.Find("Server").GetComponent<Server>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinToss();
    }

    void CoinToss()
    {
        if (Server.OnServer == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && PhotonNetwork.IsMasterClient)
            {
                Coin = Random.Range(0, 2);
                Debug.Log(Coin + "‚Å‚·");
                CoinAnim.SetInteger("CoinCheck", Coin);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Coin = 0;
                CoinAnim.SetInteger("CoinCheck", Coin);
            }
        }
    }

    public void OnAnimationEnd()
    {
        if(Server.OnServer == true)
        {
            PhotonNetwork.LoadLevel("SampleScene");
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
