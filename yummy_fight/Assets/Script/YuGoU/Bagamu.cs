using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bagamu : MonoBehaviour
{

    public CardController[] playerkitchenCardList;//調理場のカードを格納するリスト

    public GameManager manage_script;
    public GameDirecter directer;
    // Start is called before the first frame update
    void Start()
    {
        manage_script = GameObject.Find("GameManager").GetComponent<GameManager>();
        directer = GameObject.Find("GameDirecgter").GetComponent<GameDirecter>();
        gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<directer.playerkitchenCardList.Length;i++)
        {
            if (directer.playerkitchenCardList[i].gameObject.GetComponent<CardView>().cardID == 2)
            {

            }
        }
    }
}
