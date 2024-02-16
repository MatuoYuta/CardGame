using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    [SerializeField] Transform playerHand;

    void Start()
    {
        Draw();
        Draw();
        Draw();
        Draw();
        Draw();
    }

    public void Draw()
    {
        // èD‚ğ1–‡”z‚éi©•ªj
        Instantiate(cardPrefab, playerHand);
    }
}
