using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
    // Start is called before the first frame update
    public GameDirecter _directer;
    public GameManager _manager;
    public CardController _Controller;
    public GameObject hand;
    int max = 0;
    public int AtkCnt = 0;
    int hirouCnt = 0;
    public AttackButton _AttackButton;
    int[] array;
    public bool bans;
    public bool mafin;
    public bool patty;
    //int serach = 0;             //カード効果で使うドロー変数

    void Start()
    {
        _directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _Controller = GameObject.Find("CardController").GetComponent<CardController>();
        _AttackButton = GameObject.Find("AttackButton").GetComponent<AttackButton>();
        hand = GameObject.Find("Canvas/enemy_hand");
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

        array = new int[_directer.enemyHandCardList.Length];
        for (int i = 0; i < _directer.enemyHandCardList.Length; i++)  //int型の配列にenemyの手札カードのIDを保存
        {
            array[i] = _directer.enemyHandCardList[i].view.cardID;
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
        bans = false;
        mafin = false;
    }

    public void Main()
    {
        //バガムート　101 素材　バンズ 1 OR マフィン　3 と　パティ　2　と　ピクルス　4 と　レタス　6　と　トマト　8
        //チーバガ　104 素材　バンズ 1 OR マフィン　3　と　パティ　2　と チーズ　5
        //トレバガ　103 素材　バンズ 1 OR マフィン　3　と　パティ　2　と　トマト　8
        //エグマフ　102 素材　マフィン　3 と　パティ　2　と エッグ　7
        //ハーフ　105 素材　バンズ 1 OR マフィン　3 と　パティ　2


        /*array = new int[_directer.enemyHandCardList.Length];
        for (int i = 0; i < _directer.enemyHandCardList.Length; i++)  //int型の配列にenemyの手札カードのIDを保存
        {
            array[i] = _directer.enemyHandCardList[i].view.cardID;
            Debug.Log(array[i]);
        }*/

        if (_directer.EnemyFieldCardList.Length <= 2)       //フィールドに出せるカードの制限
        {
            Harf();
            //HandCheck();
            //Debug.Log("チェック１_directer.EnemyKitchenCardList.Length　" + _directer.EnemyKitchenCardList.Length);
        }
        StartCoroutine(Change_main(7));                            //メインターン終了    
        
    }
    public void kouka(int serach)
    {
        switch (serach)
        {
            case 1:
                if (!bans)
                {
                    _manager.CreateCard(2, hand.transform);   //バンズの能力を発動
                    bans = true;
                }                
                break;

            case 2:
                if (!patty)
                {
                    _manager.CreateCard(1, hand.transform);   //パティの能力を発動
                    patty = true;
                }
                break;
            case 3:
                if (!mafin)
                {
                    _manager.CreateCard(2, hand.transform);   //マフィンの能力を発動
                    mafin = true;
                }
                break;

            default:
                break;
        }
    }

    void Harf()
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
                        kouka(_directer.enemyHandCardList[a].view.cardID);
                        Debug.Log(_directer.enemyHandCardList[a].view.cardID);
                        StartCoroutine(Create(array[b], _manager.enemyKitchen, 2));//パティ
                        kouka(_directer.enemyHandCardList[b].view.cardID);
                        Destroy(_directer.enemyHandCardList[a].gameObject);
                        Destroy(_directer.enemyHandCardList[b].gameObject);
                        //StartCoroutine(Create(1, _manager.enemyField, 3));
                        StartCoroutine(Yugou(105, _manager.enemyField, 3));        //半バーガー召喚

                    }
                }
            }

        }
    }

    void Bagamu()
    {
        
        for (int a = 0; a < _directer.enemyHandCardList.Length; a++)    //手札をみて
        {

            if (_directer.enemyHandCardList[a].view.cardID == 8)        //トマトがあるとき
            {
                for (int b = 0; b < _directer.enemyHandCardList.Length; b++)
                {
                    if (_directer.enemyHandCardList[b].view.cardID == 6)  //レタスがあるとき
                    {
                        for (int c = 0; c < _directer.enemyHandCardList.Length; c++)
                        {
                            if (_directer.enemyHandCardList[c].view.cardID == 4)     //ピクルスがあるとき
                            {
                                for (int d = 0; d < _directer.enemyHandCardList.Length; d++)
                                {
                                    if (_directer.enemyHandCardList[d].view.cardID == 1 || _directer.enemyHandCardList[d].view.cardID == 3) //バンズかマフィンがあるとき
                                    {

                                    }
                                }
                            }
                        }

                    }
                }
            }

        }
    }

    void HandCheck()
    {
        for(int a = 0; a < _directer.enemyHandCardList.Length; a++)
        {
            Debug.Log("_directer.EnemyKitchenCardList.Length" + _directer.EnemyKitchenCardList.Length);
            if(_directer.EnemyKitchenCardList.Length < 1)
            {
                //StartCoroutine(wait(a, 1));
                switch (_directer.enemyHandCardList[a].view.cardID)
                {
                    case 1:
                        Create1(array[a], _manager.enemyKitchen, 1);//バンズ
                        kouka(_directer.enemyHandCardList[a].view.cardID);
                        Destroy(_directer.enemyHandCardList[a].gameObject);
                        break;
                    case 2:
                        Create1(array[a], _manager.enemyKitchen, 1);//パティ
                        kouka(_directer.enemyHandCardList[a].view.cardID);
                        Destroy(_directer.enemyHandCardList[a].gameObject);
                        break;
                    case 3:
                        Create1(array[a], _manager.enemyKitchen, 1);//マフィン
                        kouka(_directer.enemyHandCardList[a].view.cardID);
                        Destroy(_directer.enemyHandCardList[a].gameObject);
                        break;
                    case 4:
                        Create1(array[a], _manager.enemyKitchen, 1);//ピクルス
                        kouka(_directer.enemyHandCardList[a].view.cardID);
                        Destroy(_directer.enemyHandCardList[a].gameObject);
                        break;
                    case 5:
                        Create1(array[a], _manager.enemyKitchen, 1);//チーズ
                        kouka(_directer.enemyHandCardList[a].view.cardID);
                        Destroy(_directer.enemyHandCardList[a].gameObject);
                        break;
                    case 6:
                        Create1(array[a], _manager.enemyKitchen, 1);//レタス
                        kouka(_directer.enemyHandCardList[a].view.cardID);
                        Destroy(_directer.enemyHandCardList[a].gameObject);
                        break;
                    case 7:
                        Create1(array[a], _manager.enemyKitchen, 1);//エッグ
                        kouka(_directer.enemyHandCardList[a].view.cardID);
                        Destroy(_directer.enemyHandCardList[a].gameObject);
                        break;
                    case 8:
                        Create1(array[a], _manager.enemyKitchen, 1);//トマト
                        kouka(_directer.enemyHandCardList[a].view.cardID);
                        Destroy(_directer.enemyHandCardList[a].gameObject);
                        break;
                }
                Debug.Log("チェック_directer.EnemyKitchenCardList.Length　" + _directer.EnemyKitchenCardList.Length);
            }
            

        }
    }

    IEnumerator wait(int a,int wait)
    {
        Debug.Log("wait");
        yield return new WaitForSeconds(wait);
        switch (_directer.enemyHandCardList[a].view.cardID)
        {
            case 1:
                Create1(array[a], _manager.enemyKitchen, 1);//バンズ
                kouka(_directer.enemyHandCardList[a].view.cardID);
                Destroy(_directer.enemyHandCardList[a].gameObject);
                break;
            case 2:
                Create1(array[a], _manager.enemyKitchen, 1);//パティ
                kouka(_directer.enemyHandCardList[a].view.cardID);
                Destroy(_directer.enemyHandCardList[a].gameObject);
                break;
            case 3:
                Create1(array[a], _manager.enemyKitchen, 1);//マフィン
                kouka(_directer.enemyHandCardList[a].view.cardID);
                Destroy(_directer.enemyHandCardList[a].gameObject);
                break;
            case 4:
                Create1(array[a], _manager.enemyKitchen, 1);//ピクルス
                kouka(_directer.enemyHandCardList[a].view.cardID);
                Destroy(_directer.enemyHandCardList[a].gameObject);
                break;
            case 5:
                Create1(array[a], _manager.enemyKitchen, 1);//チーズ
                kouka(_directer.enemyHandCardList[a].view.cardID);
                Destroy(_directer.enemyHandCardList[a].gameObject);
                break;
            case 6:
                Create1(array[a], _manager.enemyKitchen, 1);//レタス
                kouka(_directer.enemyHandCardList[a].view.cardID);
                Destroy(_directer.enemyHandCardList[a].gameObject);
                break;
            case 7:
                Create1(array[a], _manager.enemyKitchen, 1);//エッグ
                kouka(_directer.enemyHandCardList[a].view.cardID);
                Destroy(_directer.enemyHandCardList[a].gameObject);
                break;
            case 8:
                Create1(array[a], _manager.enemyKitchen, 1);//トマト
                kouka(_directer.enemyHandCardList[a].view.cardID);
                Destroy(_directer.enemyHandCardList[a].gameObject);
                break;
        }
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

    void Create1(int id, Transform place, int wait)
    {
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
