using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CardController cardPrefab;
    [SerializeField] Transform playerHand, playerField, enemyField;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        CardController card = Instantiate(cardPrefab, playerHand);
        card.Init(1);
        CardController card2 = Instantiate(cardPrefab, playerHand);
        card2.Init(2);
        CardController card3 = Instantiate(cardPrefab, playerHand);
        card3.Init(2);
        CardController card4 = Instantiate(cardPrefab, playerHand);
        card4.Init(1);
    }

    public void Draw()
    {
        // èD‚ğ1–‡”z‚éi©•ªj
        Instantiate(cardPrefab, playerHand);
    }
}
