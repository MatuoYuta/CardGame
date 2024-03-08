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

    public Animator panel_anim;
    internal bool interactable;

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
                        _manager.CreateCard(1, hand.transform);
                        break;
                    case "Cheese(Clone)":
                        Debug.Log("チーズサーチ");
                        _manager.CreateCard(5, hand.transform);
                        break;
                    case "Egg(Clone)":
                        Debug.Log("エッグサーチ");
                        _manager.CreateCard(7, hand.transform);
                        break;
                    case "Lettuce(Clone)":
                        Debug.Log("レタスサーチ");
                        _manager.CreateCard(6, hand.transform);
                        break;
                    case "Muffin(Clone)":
                        Debug.Log("マフィンサーチ");
                        _manager.CreateCard(3, hand.transform);
                        break;
                    case "Patty(Clone)":
                        Debug.Log("パティサーチ");
                        _manager.CreateCard(2, hand.transform);
                        break;
                    case "Pickles(Clone)":
                        Debug.Log("ピクルスサーチ");
                        _manager.CreateCard(4, hand.transform);
                        break;
                    case "Tomato(Clone)":
                        Debug.Log("トマトサーチ");
                        _manager.CreateCard(8, hand.transform);
                        break;
                }
                for (int t = 0; t < _directer.SearchImageList.Length; t++)
                {
                    Destroy(_directer.SearchImageList[t].gameObject);
                }
                panel_anim.SetTrigger("Down");
            }
        }
    }
}
