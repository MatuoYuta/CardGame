using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class chibagrw : MonoBehaviour, IPointerClickHandler
{

    public CardController[] playerkitchenCardList;//í≤óùèÍÇÃÉJÅ[ÉhÇäiî[Ç∑ÇÈÉäÉXÉg

    public GameManager manage_script;
    public GameDirecter directer;
    public GameObject popup;
    public Transform playerField;
    public yugouhantei yug;

    bool click = true;
    bool aiue;
    int r, b;
    // Start is called before the first frame update
    void Start()
    {
        manage_script = GameObject.Find("GameManager").GetComponent<GameManager>();
        directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        //yug = GameObject.Find("YugouButton").GetComponent<yugouhantei>();
        //popup = GameObject.Find("popup").GetComponent<GameObject>();
        popup.SetActive(false);
        gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (directer.playerkitchenCardList[0] != null)
        {
            gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            for (int i = 0; i < directer.playerkitchenCardList.Length; i++)
            {
                if (directer.playerkitchenCardList[i].gameObject.GetComponent<CardView>().cardID == 2)
                {
                    for (int a = 0; a < directer.playerkitchenCardList.Length; a++)
                    {
                        if (directer.playerkitchenCardList[a].gameObject.GetComponent<CardView>().cardID == 5)
                        {
                            for (int j = 0; j < directer.playerkitchenCardList.Length; j++)
                            {
                                if(directer.playerkitchenCardList[j].gameObject.GetComponent<CardView>().cardID == 1 || directer.playerkitchenCardList[j].gameObject.GetComponent<CardView>().cardID == 3)
                                {
                                    gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                                    click = true;
                                    aiue = true;
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
            click = true;
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
                yug.yugou = 104;
            }

        }
    }

    /*public void OnClick()
    {
        Debug.Log("wawawa------");
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

    }*/
}

