using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class yugouhantei : MonoBehaviour
{
    public GameManager manage_script;
    public GameDirecter directer;
    public GameObject popup;
    public Transform playerField;

    public int yugou = 0;
    

    public Bagamu bagam;
    // Start is called before the first frame update
    void Start()
    {
        manage_script = GameObject.Find("GameManager").GetComponent<GameManager>();
        directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        bagam = GameObject.Find("bagamute").GetComponent<Bagamu>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Yugousyoukan();
        OnClick();
    }

    public void Yugousyoukan()
    {
        switch (yugou)
        {
            case 101:
                break;
            case 102:
                break;
            case 103:
                break;
            case 104:
                break;
            case 105:
                manage_script.CreateCard(105, playerField);
                for (int i = 0; i < directer.playerkitchenCardList.Length; i++)
                {
                    if (directer.playerkitchenCardList[i].gameObject.GetComponent<CardView>().cardID == 2)
                    {
                        Destroy(directer.playerkitchenCardList[i].gameObject);
                        Debug.Log("ëfçﬁçÌèú");
                        for (int a = 0; a < directer.playerkitchenCardList.Length; a++)
                        {
                            if (directer.playerkitchenCardList[a].gameObject.GetComponent<CardView>().cardID == 1 || directer.playerkitchenCardList[a].gameObject.GetComponent<CardView>().cardID == 3)
                            {
                                Destroy(directer.playerkitchenCardList[a].gameObject);
                                Debug.Log("ëfçﬁçÌèú2");
                                popup.SetActive(false);
                            }
                        }
                    }
                }
                break;

        }
    }
    public void OnClick()
    {
        switch (yugou)
        {
            case 101:
                break;
            case 102:
                break;
            case 103:
                break;
            case 104:
                break;
            case 105:
                manage_script.CreateCard(105, playerField);
                for (int i = 0; i < directer.playerkitchenCardList.Length; i++)
                {
                    if (directer.playerkitchenCardList[i].gameObject.GetComponent<CardView>().cardID == 2)
                    {
                        Destroy(directer.playerkitchenCardList[i].gameObject);
                        Debug.Log("ëfçﬁçÌèú");
                        for (int a = 0; a < directer.playerkitchenCardList.Length; a++)
                        {
                            if (directer.playerkitchenCardList[a].gameObject.GetComponent<CardView>().cardID == 1 || directer.playerkitchenCardList[a].gameObject.GetComponent<CardView>().cardID == 3)
                            {
                                Destroy(directer.playerkitchenCardList[a].gameObject);
                                Debug.Log("ëfçﬁçÌèú2");
                                popup.SetActive(false);
                            }
                        }
                    }
                }
                break;

        }
    }
    }
