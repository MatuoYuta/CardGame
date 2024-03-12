using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public CardView view; // �J�[�h�̌����ڂ̏���
    public CardModel model; // �J�[�h�̃f�[�^������
    public bool hirou;
    GameDirecter _directer;

    private void Awake()
    {
        view = GetComponent<CardView>();
        hirou = false;
        _directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
    }

    public void Init(int cardID) // �J�[�h�𐶐��������ɌĂ΂��֐�
    {
        Debug.Log(cardID);
        view.cardID = cardID;
        model = new CardModel(cardID); // �J�[�h�f�[�^�𐶐�
        view.Show(model); // �\��
    }
    public void Destroy_me()
    {
        Destroy(this.gameObject);
    }

    public void RotateCard()
    {
        // �J�[�h��90�x��]������
        this.transform.Rotate(new Vector3(0f, 0f, 90f));
        this.transform.localScale = new Vector3(3.5f, 0.8f, 1.3f);
        hirou = true;
    }

    public void enemyattack()
    {
        // �J�[�h��90�x��]������
        this.transform.Rotate(new Vector3(0f, 0f, -90f));
        this.transform.localScale = new Vector3(3.5f, 0.8f, 1.3f);
        hirou = true;

        _directer.enemyattack = true;
    }

    public void enemyblock()
    {
        // �J�[�h��90�x��]������
        this.transform.Rotate(new Vector3(0f, 0f, -90f));
        this.transform.localScale = new Vector3(3.5f, 0.8f, 1.3f);
        hirou = true;

        _directer.enemyattack = true;
    }

    public void kaihuku()
    {
        if (hirou)
        {
            // �J�[�h��90�x��]������
            this.transform.Rotate(new Vector3(0f, 0f, -90f));
            this.transform.localScale = new Vector3(1.3f, 2f, 1.3f);
            hirou = false;
        }
    }
}