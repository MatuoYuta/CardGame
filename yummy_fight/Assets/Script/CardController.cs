using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardController : MonoBehaviour
{
    public CardView view; // カードの見た目の処理
    public CardModel model; // カードのデータを処理
    public bool hirou,attack,block,egumahu_aru;
    GameDirecter _directer;
    GameManager _manager;
    public GameObject attack_button, blockbutton,kouka_button;
    public GameObject power_text;
    public int default_power;
    SE_Controller SE;

    private void Awake()
    {
        view = this.gameObject.GetComponent<CardView>();
        SE = GameObject.Find("SE").GetComponent<SE_Controller>();
        default_power = view.power;
        hirou = false;
        _directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        attack_button = transform.Find("Attack").gameObject;
        blockbutton = transform.Find("Block").gameObject;
        kouka_button = transform.Find("Kouka").gameObject;
        blockbutton.SetActive(false);
        kouka_button.SetActive(false);
    }
    void Update()
    {
        if (_directer.enemyattack)
        {
            enemyattack();
        }

        power_text.GetComponent<TextMeshProUGUI>().text = view.power.ToString();

        if(_directer.phase == GameDirecter.Phase.BATTLE || _directer.phase == GameDirecter.Phase.Enemy_BATTLE)
        {
            int cnt = 0;
            for (int i = 0; i < _directer.playerFieldCardList.Length; i++)
            {
                if (_directer.playerFieldCardList[i].hirou && !_manager.egumahu)
                {
                    egumahu_aru = true;
                    cnt++;
                }
            }

            if(cnt == 0)
            {
                egumahu_aru = false;
            }
        }

        if(hirou)
        {
            blockbutton.SetActive(false);
        }
        else if(!hirou && _directer.phase == GameDirecter.Phase.Enemy_BATTLE)
        {
            blockbutton.SetActive(true);
        }

        if((_directer.Attackable || _directer.Blockable) 
            && this.gameObject.GetComponent<CardView>().cardID == 102
            && !this.gameObject.GetComponent<CardController>().hirou
            && egumahu_aru)
        {
            kouka_button.SetActive(true);
        }
        else if(hirou)
        {
            kouka_button.SetActive(false);
        }
        else
        {
            kouka_button.SetActive(false);
        }
    }

    public void Init(int cardID) // カードを生成した時に呼ばれる関数
    {
        Debug.Log(cardID);
        view.cardID = cardID;
        model = new CardModel(cardID); // カードデータを生成
        view.Show(model); // 表示
    }
    public void Destroy_me()
    {
        Destroy(this.gameObject);
    }

    public void RotateCard()
    {
        // カードを90度回転させる
        this.transform.Rotate(new Vector3(0f, 0f, 90f));
        this.transform.localScale = new Vector3(3.5f, 0.8f, 1.3f);
        hirou = true;
    }

    public void power_back()
    {
        view.power = default_power;
    }

    public void enemyattack()
    {
        // カードを90度回転させる
        this.transform.Rotate(new Vector3(0f, 0f, -90f));
        this.transform.localScale = new Vector3(3.5f, 0.8f, 1.3f);
        hirou = true;
        attack = true;
        _directer.Zekkouhyoujun = true;
        Player_Block();
        _directer.life_de_ukeru.SetActive(true);
    }

    public void enemyblock()
    {
        if(!hirou)
        {
            Debug.Log("CPU：ブロックします");
            // カードを90度回転させる
            this.transform.Rotate(new Vector3(0f, 0f, -90f));
            this.transform.localScale = new Vector3(3.5f, 0.8f, 1.3f);
            block = true;
            hirou = true;

            for (int i = 0; i < _directer.playerFieldCardList.Length; i++)
            {
                if (_directer.playerFieldCardList[i].attack)
                {
                    _directer.Battle(_directer.playerFieldCardList[i].gameObject, this.gameObject);
                }
            }
        }
    }

    public void Player_Block()
    {
        for(int i = 0;i<_directer.playerFieldCardList.Length;i++)
        {
            if(!_directer.playerFieldCardList[i].hirou)
            {
                _directer.playerFieldCardList[i].gameObject.GetComponent<CardController>().blockbutton.SetActive(true);
            }
        }
    }

    public void kaihuku()
    {
        if (hirou)
        {
            // カードを90度回転させる
            this.transform.Rotate(new Vector3(0f, 0f, -90f));
            this.transform.localScale = new Vector3(1.3f, 2f, 1.3f);
            hirou = false;
        }
    }

    public void Hirou()
    {
        if(!hirou)
        {
            // カードを90度回転させる
            this.transform.Rotate(new Vector3(0f, 0f, 90f));
            this.transform.localScale = new Vector3(3.5f, 0.8f, 1.3f);
            hirou = true;
        }
    }

    public void kaihuku_Enemy()
    {
        if (hirou)
        {
            // カードを90度回転させる
            this.transform.Rotate(new Vector3(0f, 0f, 90f));
            this.transform.localScale = new Vector3(1.3f, 2f, 1.3f);
            hirou = false;
        }
    }
}