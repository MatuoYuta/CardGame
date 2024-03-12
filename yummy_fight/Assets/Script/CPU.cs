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

                StartCoroutine(Create(1, _manager.enemyKitchen,1));//�o���Y
                StartCoroutine(Create(2, _manager.enemyKitchen,2));//�p�e�B
                StartCoroutine(Yugou(105, _manager.enemyField,3));//���o�[�K�[
                StartCoroutine(Change_main(4));
                break;
            case 2:
                StartCoroutine(Create(3, _manager.enemyKitchen,1));//�}�t�B��
                StartCoroutine(Create(2, _manager.enemyKitchen,2));//�p�e�B
                StartCoroutine(Create(7, _manager.enemyKitchen,3));//�G�b�O
                StartCoroutine(Yugou(102, _manager.enemyField, 4));//�G�O�}�t

                StartCoroutine(Create(1, _manager.enemyKitchen, 5));//�o���Y
                StartCoroutine(Create(6, _manager.enemyKitchen, 6));//���^�X
                StartCoroutine(Create(8, _manager.enemyKitchen, 7));//�g�}�g
                StartCoroutine(Yugou(103, _manager.enemyField, 8));//�g���o�K

                StartCoroutine(Create(1, _manager.enemyKitchen, 9));//�o���Y
                StartCoroutine(Create(2, _manager.enemyKitchen, 10));//�p�e�B
                StartCoroutine(Create(5, _manager.enemyKitchen, 11));//�`�[�Y
                StartCoroutine(Yugou(104, _manager.enemyField, 12));//�g���o�K

                StartCoroutine(Change_main(13));
                break;
        }
    }

    IEnumerator Create(int id,Transform place, int wait)
    {
        yield return new WaitForSeconds(wait);
        _manager.CreateCard(id, place);
    }
    IEnumerator Yugou(int id, Transform place, int wait)
    {   
        yield return new WaitForSeconds(wait);
        for (int i = 0; i < _directer.EnemyKitchenCardList.Length; i++)
        {
            Destroy(_directer.EnemyKitchenCardList[i].gameObject);
        }
        _manager.CreateCard(id, place);
    }

    IEnumerator Change_main(int time)
    {
        yield return new WaitForSeconds(time);
        _directer.Change_Battle();
    }
}
