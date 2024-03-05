using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectHighlight : MonoBehaviour
{
    public string targetTag = "Card"; //オブジェクトのタグ

    private void Start()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerPress;
        Debug.Log(clickedObject);
        if (clickedObject != null && clickedObject.CompareTag(targetTag))
        {
            if (!clickedObject.GetComponent<CardMovement>().select)
            {
                clickedObject.GetComponent<CardMovement>().select = true;
                clickedObject.gameObject.GetComponent<Outline>().enabled = true;
            }
            else
            {
                clickedObject.GetComponent<CardMovement>().select = false;
                clickedObject.gameObject.GetComponent<Outline>().enabled = false;
            }
        }
    }
}