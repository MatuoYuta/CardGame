using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Ability : MonoBehaviour
{
    public GameManager manage;
    public CardMovement move_scr;
    public bool Use_Avility;
    // Start is called before the first frame update
    void Start()
    {
        manage = GameObject.Find("GameManager").GetComponent<GameManager>();
        move_scr = this.gameObject.GetComponent<CardMovement>();
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
        Use_Avility = true;
        manage.Buns = true;
    }


    public void SearchCard(Transform hand, int Cardid)
    {
        int cnt = 0;
        //search対象がなければ引かない]
        while(true)
        {
            if (manage.deck[cnt] == Cardid)
            {
                manage.deck.RemoveAt(cnt);
                manage.CreateCard(Cardid, hand);
                break;
            }
            cnt++;
        }
    }
}
