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
                        Debug.Log("�o���Y�T�[�`");
                        _manager.CreateCard(1, hand.transform);
                        break;
                    case "Cheese(Clone)":
                        Debug.Log("�`�[�Y�T�[�`");
                        _manager.CreateCard(5, hand.transform);
                        break;
                    case "Egg(Clone)":
                        Debug.Log("�G�b�O�T�[�`");
                        _manager.CreateCard(7, hand.transform);
                        break;
                    case "Lettuce(Clone)":
                        Debug.Log("���^�X�T�[�`");
                        _manager.CreateCard(6, hand.transform);
                        break;
                    case "Muffin(Clone)":
                        Debug.Log("�}�t�B���T�[�`");
                        _manager.CreateCard(3, hand.transform);
                        break;
                    case "Patty(Clone)":
                        Debug.Log("�p�e�B�T�[�`");
                        _manager.CreateCard(2, hand.transform);
                        break;
                    case "Pickles(Clone)":
                        Debug.Log("�s�N���X�T�[�`");
                        _manager.CreateCard(4, hand.transform);
                        break;
                    case "Tomato(Clone)":
                        Debug.Log("�g�}�g�T�[�`");
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
