using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameDirecter _directer;
    [SerializeField]
    private GameManager _manager;
    public GameObject hand;
    internal object onClick;

    public int search_id;
    private int cnt;
    public Animator panel_anim;

    void Start()
    {
        hand = GameObject.Find("Player_hand");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Push()
    {
        _directer.NextPhase();
    }

    public void Select()
    {
        for(int i = 0;i<_directer.SearchImageList.Length;i++)
        {
            if(_directer.SearchImageList[i].selected)
            {
                Debug.Log(_directer.SearchImageList[i].gameObject.name);
                switch (_directer.SearchImageList[i].gameObject.name)
                {
                    case "Buns(Clone)":
                        Debug.Log("バンズサーチ");
                        search_id = 1;
                        _manager.CreateCard(search_id, hand.transform);
                        break;
                    case "Cheese(Clone)":
                        Debug.Log("チーズサーチ");
                        search_id = 5;
                        _manager.CreateCard(search_id, hand.transform);
                        break;
                    case "Egg(Clone)":
                        Debug.Log("エッグサーチ");
                        search_id = 7;
                        _manager.CreateCard(search_id, hand.transform);
                        break;
                    case "Lettuce(Clone)":
                        Debug.Log("レタスサーチ");
                        search_id = 6;
                        _manager.CreateCard(search_id, hand.transform); 
                        break;
                    case "Muffin(Clone)":
                        Debug.Log("マフィンサーチ");
                        search_id = 3;
                        _manager.CreateCard(search_id, hand.transform); 
                        break;
                    case "Patty(Clone)":
                        Debug.Log("パティサーチ");
                        search_id = 2;
                        _manager.CreateCard(search_id, hand.transform); 
                        break;
                    case "Pickles(Clone)":
                        Debug.Log("ピクルスサーチ");
                        search_id = 4;
                        _manager.CreateCard(search_id, hand.transform); 
                        break;
                    case "Tomato(Clone)":
                        Debug.Log("トマトサーチ");
                        search_id = 8;
                        _manager.CreateCard(search_id, hand.transform); 
                        break;
                }
                while (cnt == 0)
                {
                    for (int n = 0; n < _manager.deck.Count; n++)
                    {
                        if (_manager.deck[n] == search_id)
                        {
                            _manager.deck.RemoveAt(n);
                            cnt++;
                            break;
                        }
                    }
                }

                cnt = 0;
                panel_anim.SetTrigger("Down");
                for (int t = 0; t < _directer.SearchImageList.Length; t++)
                {
                    Destroy(_directer.SearchImageList[t].gameObject);
                }
            }
        }
    }
}
