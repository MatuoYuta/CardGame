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
        }
    }

    // Update is called once per frame
    void Update()
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
    }

}
