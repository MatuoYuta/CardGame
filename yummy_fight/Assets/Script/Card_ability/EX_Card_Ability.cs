using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_Card_Ability : MonoBehaviour
{
   public  GameDirecter directer_script;
    public bool baga;
    // Start is called before the first frame update
    void Start()
    {
        directer_script = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        switch (this.GetComponent<CardModel>().cardID)
        {
            case 101:
                Bagamute();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bagamute()
    {
        if(baga)
        {
            for (int i = 0; i < directer_script.EnemyFieldCardList.Length; i++)
            {
                Destroy(directer_script.EnemyFieldCardList[i].gameObject);
            }
        }

    }
}
