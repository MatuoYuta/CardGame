using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
    // Start is called before the first frame update
    public GameDirecter _directer;
    public GameManager _manager;
    void Start()
    {
        _directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Standby()
    {
        for(int i = 0; i< _directer.EnemyKitchenCardList.Length;i++)
        {
            _directer.EnemyKitchenCardList[i].gameObject.transform.SetParent(_manager.enemyField);
        }
    }

    public void Main(int turn)
    {
        switch (turn)
        {
            case 1:

                StartCoroutine(Create(1, _manager.enemyKitchen));
                StartCoroutine(Create(1, _manager.enemyKitchen));
                StartCoroutine(Yugou(105, _manager.enemyField));
                StartCoroutine("Change_main");
                break;
            case 2:
                StartCoroutine("Change_main");
                break;
        }
    }

    IEnumerator Create(int id,Transform place)
    {
        yield return new WaitForSeconds(1);
        _manager.CreateCard(id, place);
    }
    IEnumerator Yugou(int id, Transform place)
    {   
        yield return new WaitForSeconds(3);
        for (int i = 0; i < _directer.EnemyKitchenCardList.Length; i++)
        {
            Destroy(_directer.EnemyKitchenCardList[i].gameObject);
        }
        _manager.CreateCard(id, place);
    }

    IEnumerator Change_main()
    {
        yield return new WaitForSeconds(1);
        _directer.Change_Battle();
    }
}
