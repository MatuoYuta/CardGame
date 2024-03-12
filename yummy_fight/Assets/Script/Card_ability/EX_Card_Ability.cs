using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_Card_Ability : MonoBehaviour
{
   public  GameDirecter directer_script;
    // Start is called before the first frame update
    void Start()
    {
        directer_script = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        switch (this.GetComponent<CardView>().cardID)
        {
            case 101:
                Debug.Log("ÉoÉKÉÄÅ[Ég");
                StartCoroutine("Bagamute");
                break;
            case 102:
                StartCoroutine("Egumahu");
                break;
            case 103:
                StartCoroutine("Torebaga");
                break;
            case 104:
                StartCoroutine("Chibaga");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Select_Card()
    {

    }

    IEnumerator Bagamute()
    {
        yield return new WaitForSeconds(1);

        Debug.Log(directer_script.EnemyFieldCardList.Length);
        for (int i = 0; i < directer_script.EnemyFieldCardList.Length; i++)
        {
            Debug.Log(directer_script.EnemyFieldCardList[i].gameObject);
            directer_script.EnemyFieldCardList[i].gameObject.GetComponent<CardController>().Destroy_me();
        }

        for(int t = 0; t<directer_script.playerFieldCardList.Length;t++)
        {
            Debug.Log(directer_script.playerFieldCardList[t].gameObject);
            if (directer_script.playerFieldCardList[t].gameObject.GetComponent<CardView>().cardID != 101)
            {
                directer_script.playerFieldCardList[t].gameObject.GetComponent<CardController>().Destroy_me();
            }
        }
    }

    IEnumerator Egumahu()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator Torebaga()
    {
        yield return new WaitForSeconds(1);

    }

    IEnumerator Chibaga()
    {
        yield return new WaitForSeconds(1);

      
    }

}
