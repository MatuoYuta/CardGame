using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform cardParent;
    public Transform before;

    void Start()
    {
        Debug.Log(this.transform.localScale);
    }

    public void OnBeginDrag(PointerEventData eventData) // �h���b�O���n�߂�Ƃ��ɍs������
    {
        cardParent = transform.parent;
        transform.SetParent(cardParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false; // blocksRaycasts���I�t�ɂ���
    }

    public void OnDrag(PointerEventData eventData) // �h���b�O�������ɋN��������
    {
        transform.position = eventData.position;
        Debug.Log(this.transform.localScale);
    }

    public void OnEndDrag(PointerEventData eventData) // �J�[�h�𗣂����Ƃ��ɍs������
    {
        transform.SetParent(cardParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true; // blocksRaycasts���I���ɂ���
        Debug.Log(this.transform.localScale);
    }
}
