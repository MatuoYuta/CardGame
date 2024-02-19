using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerHand;
    public GameManager manage_script;
    // Start is called before the first frame update
    void Start()
    {
        manage_script = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerHand = GameObject.Find("Player_hand").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        
    }

    public void Draw()
    {
        manage_script.DrawCard(playerHand);
    }
}
