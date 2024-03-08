using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Ability : MonoBehaviour
{
    public GameManager manage;
    public CardMovement move_scr;
    public GameDirecter directer;
    public bool Use_Avility;

    public SearchArea search_script;
    public GameObject scroll_view;
    public CardController[] Search_Card;
    public Animator panel_anim;

    private int cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        search_script = GameObject.Find("Content").GetComponent<SearchArea>();
        manage = GameObject.Find("GameManager").GetComponent<GameManager>();
        directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        scroll_view = GameObject.Find("Select_Area");
        move_scr = this.gameObject.GetComponent<CardMovement>();
        panel_anim = scroll_view.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(move_scr.cardParent != null)//親要素がヌルじゃなければ
        {
            if (!Use_Avility && move_scr.cardParent == GameObject.Find("Player_kitchen").transform)
            {
                switch (this.GetComponent<CardView>().cardID)
                {
                    case 1:
                        if(!manage.Buns)
                        {
                            Buns();
                        }
                        break;
                    case 2:
                        if (!manage.Patty)
                        {
                            Patty();
                        }
                        break;
                    case 3:
                        if (!manage.Muffin)
                        {
                            Muffin();
                        }
                        break;
                    case 4:
                        if(!manage.Pickles)
                        {
                            Pickles();
                        }
                        break;
                }
            }
            else
            {

            }
        }

    }

    public void Buns()
    {
        SearchCard(manage.playerHand, 2);//パティサーチ
        Use_Avility = true;
        manage.Buns = true;
        
    }
    public void Patty()
    {
        SearchCard(manage.playerHand, 1);//バンズをサーチ
        SearchCard(manage.playerHand, 3);//マフィンをサーチ
        Use_Avility = true;
        manage.Patty = true;
    }

    public void Muffin()
    {
        SearchCard(manage.playerHand, 2);//パティサーチ
        Use_Avility = true;
        manage.Muffin = true;
    }

    public void Pickles()
    {
        SearchCard(manage.playerHand, 5);
        SearchCard(manage.playerHand, 6);
        SearchCard(manage.playerHand, 7);
        SearchCard(manage.playerHand, 8);
        Use_Avility = true;
        manage.Pickles = true;
    }




    public void SearchCard(Transform hand, int Cardid)
    {
       for(int i = 0;i<directer.SearchImageList.Length;i++)
        {
            Destroy(directer.SearchImageList[i].gameObject);
        }

        for (int i = 0;i<manage.deck.Count;i++)
        {
            if(manage.deck[i] == Cardid)
            {
                search_script.CreatePrefab(Cardid);
                cnt++;
            }
        }

        if(cnt != 0)
        {
            panel_anim.SetTrigger("Up");
            scroll_view.SetActive(true);
        }
    }
}
