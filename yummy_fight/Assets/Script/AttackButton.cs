using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    public GameObject cardObject; // �������ɂ���Card�I�u�W�F�N�g
    public GameDirecter _directer;
    public CardController _controller;
    private Button attackButton; // �{�^���̎Q��
    public bool hirou;

    void Start()
    {
        _directer = GameObject.Find("GameDirecter").GetComponent<GameDirecter>();
        _controller = cardObject.GetComponent<CardController>();
        // �{�^���R���|�[�l���g���擾
        attackButton = GetComponent<Button>();
        this.gameObject.SetActive(false);
    }

    public void OnAttackButtonClick()
    {
        Debug.Log("����ɍU������");
        cardObject.GetComponent<CardController>().attack = true;
        _controller.RotateCard(); // �J�[�h���������ɂ��郁�\�b�h���Ăяo��
        AttackPlayer(); // �v���C���[�ɍU�����郁�\�b�h���Ăяo��
        // �{�^�����\���ɂ���
        gameObject.SetActive(false);
    }

    void AttackPlayer()
    {
        _directer.playerattack = true;
        if(_directer.EnemyFieldCardList.Length == 0)
        {
            cardObject.GetComponent<CardController>().attack = false;
            _directer.playerattack = false;
            _directer.enemy_life--;
        }

        //// �v���C���[�I�u�W�F�N�g���^�O�Ō������Ď擾
        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        //// �v���C���[�I�u�W�F�N�g�����݂���ꍇ
        //if (player != null)
        //{
        //    // �v���C���[�I�u�W�F�N�g�Ƀ_���[�W��^����Ȃǂ̏����������ɋL�q
        //    // �ȉ��̓_���[�W��^���鏈���̗�
        //    PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        //    if (playerHealth != null)
        //    {
        //        playerHealth.TakeDamage(1); // ��Ƃ���10�̃_���[�W��^����
        //    }
        //}
        //else
        //{
        //    Debug.LogWarning("�v���C���[�I�u�W�F�N�g��������܂���ł����I");
        //}

    }
}
