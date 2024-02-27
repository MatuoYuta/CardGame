using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinT : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Coin = Random.Range(0, 2);
            Debug.Log(Coin);
            CoinAnim.SetInteger("CoinCheck",Coin);
        }
    }
}
