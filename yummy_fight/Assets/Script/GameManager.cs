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
        // ��D��1���z��i�����j
        Instantiate(cardPrefab, playerHand);
    }
}
