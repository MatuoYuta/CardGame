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
        // 手札を1枚配る（自分）
        Instantiate(cardPrefab, playerHand);
    }
}
