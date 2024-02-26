using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform cardParent;
    private Vector2 prevPos;
    public Transform before_parent;
    public GameManager manage_script;
    public bool kitchen, field, change;
    GameDirecter directer_script;

    void Start()
    {
        manage_script = GameObject.Find("GameManager").GetComponent<GameManager>();
        directer_script = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        cardParent = GameObject.Find("Player_hand").transform;
        change = true;
        Debug.Log(this.transform.localScale);
        transform.eulerAngles = new Vector3(0, 0, 0); // X���𒆐S��45����]�AY��Z���͏����l
    }

    void Update()
    {

        if (directer_script.playerkitchenCardList.Length < 5 )//������̃J�[�h���T�������̎��ɒu����悤�ɂ���
        {
            kitchen = true;
        }
        else
        {
            kitchen = false;
        }

        if (directer_script.playerFieldCardList.Length < 3 && cardParent == GameObject.Find("Player_kitchen").transform)//�t�B�[���h�̃J�[�h���R�������̎��ɒu����悤�ɂ���
        {
            field = true;
        }
        else
        {
            field = false;
        }

        if(directer_script.Movable && change)
        {
            Debug.Log("�����܂�");
            GetComponent<CanvasGroup>().blocksRaycasts = true; // blocksRaycasts���I���ɂ���
            change = false;
        }

        if(!directer_script.Movable)
        {
            Debug.Log("�����܂���");
            change = true;
            //GetComponent<CanvasGroup>().blocksRaycasts = false; // blocksRaycasts���I�t�ɂ���
        }
    }

    public void OnBeginDrag(PointerEventData eventData) // �h���b�O���n�߂�Ƃ��ɍs������
    {
        before_parent = transform.parent.gameObject.transform;
        prevPos = this.transform.position;
        cardParent = transform.parent;
        transform.SetParent(cardParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false; // blocksRaycasts���I�t�ɂ���
    }

    public void OnDrag(PointerEventData eventData) // �h���b�O�������ɋN��������
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) // �J�[�h�𗣂����Ƃ��ɍs������
    {
        change = true;
        //�X�^���o�C�t�F�[�Y�̈ړ�(�t�B�[���h����L�b�`��)
        if (kitchen && cardParent == GameObject.Find("Player_kitchen").transform && before_parent == GameObject.Find("Player_field").transform && !directer_script.Summonable && !directer_script.Attackable)//������ɃJ�[�h��u������
        {
            transform.SetParent(cardParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true; // blocksRaycasts���I���ɂ���
        }
        //�X�^���o�C�t�F�[�Y�̈ړ�(�L�b�`������t�B�[���h)
        else if (field && cardParent == GameObject.Find("Player_field").transform && before_parent == GameObject.Find("Player_kitchen").transform && !directer_script.Summonable && !directer_script.Attackable)//�t�B�[���h�ɃJ�[�h��u������
        {
            transform.SetParent(cardParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true; // blocksRaycasts���I���ɂ���
        }
        //���C���t�F�[�Y�̏���(��D����L�b�`��)
        else if(kitchen && cardParent == GameObject.Find("Player_kitchen").transform &&  before_parent == GameObject.Find("Player_hand").transform && directer_script.Summonable && !directer_script.Attackable)
        {
            transform.SetParent(cardParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true; // blocksRaycasts���I���ɂ���
        }

        else
        {
            this.transform.position = prevPos;
            cardParent = before_parent;
            transform.SetParent(before_parent);
            GetComponent<CanvasGroup>().blocksRaycasts = true; // blocksRaycasts���I���ɂ���
        };
    }
}
