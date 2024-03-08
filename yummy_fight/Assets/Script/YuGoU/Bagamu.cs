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

    bool click;
    int r, b;
    // Start is called before the first frame update
    void Start()
    {
        manage_script = GameObject.Find("GameManager").GetComponent<GameManager>();
        directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        //popup = GameObject.Find("popup").GetComponent<GameObject>();
        popup.SetActive(false);
        Debug.Log("色が変わります");
        gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        Debug.Log("色が変わりました");

    }

    // Update is called once per frame
    void Update()
    {
        if (directer.playerkitchenCardList[(directer.playerkitchenCardList.Length - 1)] != null)
        {
            for (int i = 0; i < directer.playerkitchenCardList.Length; i++)
            {
                if (directer.playerkitchenCardList[i].gameObject.GetComponent<CardView>().cardID == 2)
                {
                    for (int a = 0; a < directer.playerkitchenCardList.Length; a++)
                    {
                        if (directer.playerkitchenCardList[a].gameObject.GetComponent<CardView>().cardID == 1 || directer.playerkitchenCardList[a].gameObject.GetComponent<CardView>().cardID == 3)
                        {

                            gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                            click = true;

                        }
                    }
                }
            }
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (click)
        {
            popup.SetActive(true);

            click = false;
        }
    }

    public void OnClick()
    {
        Debug.Log("wawawa------");
        manage_script.CreateCard(105, playerField);
        for (int i = 0; i < directer.playerkitchenCardList.Length; i++)
        {
            if (directer.playerkitchenCardList[i].gameObject.GetComponent<CardView>().cardID == 2)
            {
                Destroy(directer.playerkitchenCardList[i].gameObject);
                Debug.Log("素材削除");
                for (int a = 0; a < directer.playerkitchenCardList.Length; a++)
                {
                    if (directer.playerkitchenCardList[a].gameObject.GetComponent<CardView>().cardID == 1 || directer.playerkitchenCardList[a].gameObject.GetComponent<CardView>().cardID == 3)
                    {
                        Destroy(directer.playerkitchenCardList[a].gameObject);
                        gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                        Debug.Log("素材削除2");
                        click = false;
                        Debug.Log(click);
                        popup.SetActive(false);
                    }
                }
            }
        }
      
    }
}
