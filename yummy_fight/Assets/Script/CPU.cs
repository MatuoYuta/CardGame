using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
    // Start is called before the first frame update
    public GameDirecter _directer;
    public GameManager _manager;
    public CardController _Controller;
    int max = 0;

    //手札に何があるか
    bool paty;
    bool bans;
    bool mahin;
    bool piclus;
    bool chees;
    bool retasu;
    bool egg;
    bool tomato;
    

    void Start()
    {
        _directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_directer.playerattack)
        {
            Debug.Log("プレイヤーの攻撃を検知");
            if(!_directer.Koukahatudou)
            {
                StartCoroutine("Block");
            }
        }
    }

    public IEnumerator Block()
    {
        yield return new WaitForSeconds(0);
        if (_directer.EnemyFieldCardList.Length > 0)
        {
            for (int i = 0; i < _directer.EnemyFieldCardList.Length; i++)
            {
                if (max < _directer.EnemyFieldCardList[i].GetComponent<CardView>().power)
                {
                    max = _directer.EnemyFieldCardList[i].GetComponent<CardView>().power;
                }
            }

            for (int i = 0; i < _directer.EnemyFieldCardList.Length; i++)
            {
                if (max == _directer.EnemyFieldCardList[i].GetComponent<CardView>().power)
                {
                    _directer.EnemyFieldCardList[i].enemyblock();
                    _directer.playerattack = false;

                }
            }
        }
    }

    public void Standby()
    {
        for(int i = 0; i< _directer.EnemyKitchenCardList.Length;i++)
        {
            _directer.EnemyKitchenCardList[i].gameObject.transform.SetParent(_manager.enemyField);
        }

        
        
    }

    public void Main()
    {
       
        int[] array = new int[_directer.enemyHandCardList.Length];
        for (int i = 0; i < _directer.enemyHandCardList.Length; i++)  //int型の配列にenemyの手札カードのIDを保存
        {
            array[i] = _directer.enemyHandCardList[i].view.cardID;
            Debug.Log(array[i]);
        }

        if (_directer.EnemyFieldCardList.Length <= 2)       //フィールドに出せるカードの制限
        {
            for (int a = 0; a < _directer.enemyHandCardList.Length; a++)    //手札をみて
            {
                if (_directer.enemyHandCardList[a].view.cardID == 1 || _directer.enemyHandCardList[a].view.cardID == 3)        //バンズがあるときかマフィンがあるとき
                {
                     
                    for (int b = 0; b < _directer.enemyHandCardList.Length; b++)
                    {
                        if (_directer.enemyHandCardList[b].view.cardID == 2)  //パティ
                        {
                            
                            
                            StartCoroutine(Create(array[a], _manager.enemyKitchen, 1));//バンズorマフィン
                            StartCoroutine(Create(array[b], _manager.enemyKitchen, 2));//パティ
                            Destroy(_directer.enemyHandCardList[a].gameObject);
                            Destroy(_directer.enemyHandCardList[b].gameObject);
                            StartCoroutine(Create(4, _manager.enemyField, 3));         //ピクルス                          
                            StartCoroutine(Create(5, _manager.enemyField, 3));         //チーズ
                            StartCoroutine(Yugou(105, _manager.enemyField, 3));        //半バーガー召喚
                            StartCoroutine(Change_main(4));                            //メインターン終了
                            //paty = true;
                        }
                      
                    }
                }
                break;
            }
            //paty = false;
        }
            

        /*if(_directer.EnemyFieldCardList.Length <= 2)
        {
            for(int q = 0; q <= _directer.EnemyFieldCardList.Length; q++)
            {

            }
        }*/

        

            /*switch (turn)
        {
            
            case 1:

                StartCoroutine(Create(1, _manager.enemyKitchen, 1));//バンズ
                StartCoroutine(Create(2, _manager.enemyKitchen, 2));//パティ
                StartCoroutine(Yugou(105, _manager.enemyField, 3));//半バーガー
                StartCoroutine(Change_main(4));
                break;
            case 2:
                StartCoroutine(Create(3, _manager.enemyKitchen, 1));//マフィン
                StartCoroutine(Create(2, _manager.enemyKitchen, 2));//パティ
                StartCoroutine(Create(7, _manager.enemyKitchen, 3));//エッグ
                StartCoroutine(Yugou(102, _manager.enemyField, 4));//エグマフ

                StartCoroutine(Create(1, _manager.enemyKitchen, 5));//バンズ
                StartCoroutine(Create(6, _manager.enemyKitchen, 6));//レタス
                StartCoroutine(Create(8, _manager.enemyKitchen, 7));//トマト
                StartCoroutine(Yugou(103, _manager.enemyField, 8));//トレバガ

                *//*StartCoroutine(Create(1, _manager.enemyKitchen, 9));//バンズ
                StartCoroutine(Create(2, _manager.enemyKitchen, 10));//パティ
                StartCoroutine(Create(5, _manager.enemyKitchen, 11));//チーズ
                StartCoroutine(Yugou(104, _manager.enemyField, 12));//トレバガ*//*

                StartCoroutine(Change_main(13));
                break;
        }*/
    }


    public void battle(int turn)
    {
        int maxPower = 0;
        
        if(_directer.EnemyFieldCardList.Length > 0) //CPUのフィールドにカードが一枚以上あるとき
        {
            for (int i = 1; i < _directer.EnemyFieldCardList.Length; i++)   //CPUのフィールドのカードを見ていく
            {
                if (_directer.EnemyFieldCardList[maxPower].view.power < _directer.EnemyFieldCardList[i].view.power　&& _directer.EnemyFieldCardList[i].view.hirou == false ) //攻撃力が最も高いカードを探す
                {
                    maxPower = i;   //登録
                    Debug.Log(_directer.EnemyFieldCardList[maxPower].view.power);
                }
            }

            if (_directer.playerFieldCardList.Length == 0)
            {

            }

            
        }
        
        
        /*switch(turn)
        {
            case 1:
                _directer.Change_End();
                break;
                
            case 2:
                for(int i=0;i<_directer.EnemyFieldCardList.Length;i++)
                {
                    if(_directer.EnemyFieldCardList[i].gameObject.GetComponent<CardView>().cardID == 102)
                    {
                        _directer.EnemyFieldCardList[i].enemyattack();
                    }
                }
                break;
        }*/
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

    IEnumerator enemy_attack()
    {
        _directer.enemyattack = true;
        yield return new WaitForSeconds(0.1f);
    }
}
