using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Bagamu : MonoBehaviour, IPointerClickHandler
{

    public CardController[] playerkitchenCardList;//調理場のカードを格納するリスト

    public GameManager manage_script;
    public GameDirecter directer;
    public GameObject popup;
    public Transform playerField;
    public yugouhantei yug;

    bool click = true;
    bool aiue;
    // Start is called before the first frame update
    void Start()
    {
        manage_script = GameObject.Find("GameManager").GetComponent<GameManager>();
        directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        //yug = GameObject.Find("YugouButton").GetComponent<yugouhantei>();
        //popup = GameObject.Find("popup").GetComponent<GameObject>();
        popup.SetActive(false);
        Debug.Log("色が変わります");
        gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        Debug.Log("色が変わりました");

    }

    // Update is called once per frame
    void Update()
    {
        if (directer.playerkitchenCardList[0] != null)
        {
            gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            for (int i = 0; i < directer.playerkitchenCardList.Length; i++)
            {
                if (directer.playerkitchenCardList[i].gameObject.GetComponent<CardView>().cardID == 1 || directer.playerkitchenCardList[i].gameObject.GetComponent<CardView>().cardID == 3)
                {
                    for (int a = 0; a < directer.playerkitchenCardList.Length; a++)
                    {
                        if (directer.playerkitchenCardList[a].gameObject.GetComponent<CardView>().cardID == 2)
                        {
                                    for(int w = 0;w < directer.playerkitchenCardList.Length; w++)
                                    {
                                        if(directer.playerkitchenCardList[w].gameObject.GetComponent<CardView>().cardID == 4)
                                        {
                                            for(int y = 0;y  < directer.playerkitchenCardList.Length; y++)
                                            {
                                                if(directer.playerkitchenCardList[y].gameObject.GetComponent<CardView>().cardID == 6)
                                                {
                                                    for(int m = 0;m < directer.playerkitchenCardList.Length; m++)
                                                    {
                                                        if(directer.playerkitchenCardList[m].gameObject.GetComponent<CardView>().cardID == 8)
                                                        {
                                                            gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                                                            aiue = true;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                        }
                    }
                }
            }
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            aiue = false;
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (click)
        {

            if (aiue == true)
            {
                popup.SetActive(true);
                yug.yugou = 101;
            }

        }
    }
}

