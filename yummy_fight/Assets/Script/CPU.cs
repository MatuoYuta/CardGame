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
    public int AtkCnt = 0;
    int hirouCnt = 0;
    public AttackButton _AttackButton;
    public bool bans;
    public bool mafin;

    void Start()
    {
        _directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _Controller = GameObject.Find("CardController").GetComponent<CardController>();
        _AttackButton = GameObject.Find("AttackButton").GetComponent<AttackButton>();
    }

    //バガムート　101 素材　バンズ 1 OR マフィン　3 と　パティ　2　と　ピクルス　4 と　レタス　6　と　トマト　8
    //チーバガ　104 素材　バンズ 1 OR マフィン　3　と　パティ　2　と チーズ　5
    //トレバガ　103 素材　バンズ 1 OR マフィン　3　と　パティ　2　と　トマト　8
    //エグマフ　102 素材　マフィン　3 と　パティ　2　と エッグ　7
    //ハーフ　105 素材　バンズ 1 OR マフィン　3 と　パティ　2
    // Update is called once per frame
    void Update()
    {
        if(_directer.playerattack)
        {
            Debug.Log("プレイヤーの攻撃を検知");
            if(!_directer.Koukahatudou && _directer.EnemyFieldCardList.Length > 0)
            {
                for (int i = 0; i < _directer.EnemyFieldCardList.Length; i++)
                {
                    if (_directer.EnemyFieldCardList[i].view.hirou)
                    {
                        hirouCnt++;
                    }
                }
                if(_directer.EnemyFieldCardList.Length <= hirouCnt)     //enemyFieldがすべて疲労状態なら
                {
                    _directer.enemy_life--;
                    _AttackButton.cardObject.GetComponent<CardController>().attack = false;
                    _directer.playerattack = false;
                }
                

                StartCoroutine("Block");
            }
        }
    }

    public IEnumerator Block()      
    {
        yield return new WaitForSeconds(0);
        if (_directer.EnemyFieldCardList.Length > 0)    //CPUのフィールドに1体以上モンスターがいるとき
        {
            for (int i = 0; i < _directer.EnemyFieldCardList.Length; i++)
            {
                if (max < _directer.EnemyFieldCardList[i].GetComponent<CardView>().power && _directer.EnemyFieldCardList[i].view.hirou == false)   //もっともパワーが高いやつを探す
                {
                    max = _directer.EnemyFieldCardList[i].GetComponent<CardView>().power;   //入れる
                }
            }

            for (int i = 0; i < _directer.EnemyFieldCardList.Length; i++)
            {
                if (max == _directer.EnemyFieldCardList[i].GetComponent<CardView>().power && _directer.EnemyFieldCardList[i].view.hirou == false)  //一番パワーでかいやつを探す
                {
                    _directer.EnemyFieldCardList[i].enemyblock();   //おったらそいつでブロック
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
        for (int i = 0; i < _directer.EnemyFieldCardList.Length; i++)
        {
            _directer.EnemyFieldCardList[i].kaihuku_Enemy();
            _directer.EnemyFieldCardList[i].view.hirou = false;
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
                if (_directer.enemyHandCardList[a].view.cardID == 1 || _directer.enemyHandCardList[a].view.cardID == 3 && !bans && !mafin)        //バンズがあるときかマフィンがあるとき
                {                   
                    for (int b = 0; b < _directer.enemyHandCardList.Length; b++)
                    {
                        if (_directer.enemyHandCardList[b].view.cardID == 2)  //パティがあるとき
                        {   
                            StartCoroutine(Create(array[a], _manager.enemyKitchen, 1));//バンズorマフィン
                            /*if(_directer.enemyHandCardList[a].view.cardID == 1)
                            {
                                StartCoroutine(Create(3, _manager.enemyHand, 1));   //バンズの能力を発動
                                bans = true;
                            }
                            else if(_directer.enemyHandCardList[a].view.cardID == 3)
                            {
                                StartCoroutine(Create(1, _manager.enemyHand, 1));   //マフィンの能力を発動
                                mafin = true;
                            }*/
                            StartCoroutine(Create(array[b], _manager.enemyKitchen, 2));//パティ

                            Destroy(_directer.enemyHandCardList[a].gameObject);
                            Destroy(_directer.enemyHandCardList[b].gameObject);

                            StartCoroutine(Create(1, _manager.enemyField, 3));
                            StartCoroutine(Yugou(105, _manager.enemyField, 3));        //半バーガー召喚
                           
                        }                     
                    }
                }
                break;
            }
        }
        StartCoroutine(Change_main(7));                            //メインターン終了    

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
        
        
        if(_directer.EnemyFieldCardList.Length > 0) //CPUのフィールドにカードが一枚以上あるとき
        {          
            EnemyAttackJudge();
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

    public void EnemyAttackJudge()
    {
        Debug.Log("EnemyAttackJudgeの実行");
        if (AtkCnt == _directer.EnemyFieldCardList.Length)
        {
            Debug.Log("エンドフェイズ突入" + AtkCnt);
            _directer.Change_End();
            AtkCnt = 0;
        }

        int P_maxPower = 0;
        if(_directer.playerFieldCardList.Length <= 0)
        {
            //P_maxPower = 100;
        }
        else
        {
            for (int i = 1; i < _directer.playerFieldCardList.Length; i++)   //プレイヤーのフィールドのカードを見ていく
            {
                if (_directer.playerFieldCardList[P_maxPower].view.power < _directer.playerFieldCardList[i].view.power && _directer.playerFieldCardList[i].view.hirou == false) //攻撃力が最も高いカードを探す
                {
                    P_maxPower = i;   //登録                
                }
            }
        }
        

        int maxPower = 0;
        for (int i = 1; i < _directer.EnemyFieldCardList.Length; i++)   //CPUのフィールドのカードを見ていく
        {
            if (_directer.EnemyFieldCardList[maxPower].view.power < _directer.EnemyFieldCardList[i].view.power && _directer.EnemyFieldCardList[i].view.hirou == false) //攻撃力が最も高いカードを探す
            {
                maxPower = i;   //登録                
            }                   
        }

        if (!_directer.EnemyFieldCardList[maxPower].view.hirou)    //カードが疲労状態じゃないなら攻撃
        {
            if(_directer.playerFieldCardList.Length == 0)
            {
                _directer.EnemyFieldCardList[maxPower].enemyattack();
                _directer.EnemyFieldCardList[maxPower].view.hirou = true;
                AtkCnt++;
                Debug.Log("AtkCnt" + AtkCnt);
            }
            else if (_directer.playerFieldCardList[P_maxPower].view.power　<= _directer.EnemyFieldCardList[maxPower].view.power)
            {
                _directer.EnemyFieldCardList[maxPower].enemyattack();
                _directer.EnemyFieldCardList[maxPower].view.hirou = true;
                AtkCnt++;
                Debug.Log("AtkCnt" + AtkCnt);
                maxPower = 0;

                
            }
            else if(_directer.playerFieldCardList[P_maxPower].view.power > _directer.EnemyFieldCardList[maxPower].view.power)
            {
                Debug.Log("P_maxPower"+P_maxPower);
                Debug.Log("_directer.playerFieldCardList.Length"+_directer.playerFieldCardList.Length);
                Debug.Log("_directer.playerFieldCardList[P_maxPower].view.power"+_directer.playerFieldCardList[P_maxPower].view.power);
                Debug.Log("↓");
                maxPower = 0;
                P_maxPower = 0;
                _directer.Change_End();
            }
            
        }
        maxPower = 0;
        


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
