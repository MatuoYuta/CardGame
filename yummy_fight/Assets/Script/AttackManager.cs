using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    public GameObject attackButton; // �U���{�^����GameObject
    public GameObject selectedCard; // �I�����ꂽ�J�[�h��GameObject

    void Start()
    {
        attackButton.SetActive(false); // �Q�[���J�n���͍U���{�^�����\���ɂ���
    }

    void Update()
    {
        // �J�[�h���I������Ă��邩�ǂ������m�F���A�U���{�^����\������
        if (selectedCard != null && IsCardInBattleZone(selectedCard))
        {
            attackButton.SetActive(true);
        }
        else
        {
            attackButton.SetActive(false);
        }
    }

    // �J�[�h���o�g���]�[���ɂ��邩�ǂ����𔻒肷��֐�
    bool IsCardInBattleZone(GameObject card)
    {
        // �����Ƀo�g���]�[���Ɋւ��锻�菈������������
        // �Ⴆ�΁A�J�[�h������̗̈���ɂ��邩�ǂ������m�F����Ȃ�
        return true; // ���̎����Ƃ��ď��true��Ԃ�
    }

    // �J�[�h���I�����ꂽ�Ƃ��ɌĂяo�����֐�
    public void CardSelected(GameObject selectedCard)
    {
        this.selectedCard = selectedCard;
    }

    // �U���{�^���������ꂽ�Ƃ��ɌĂяo�����֐�
    public void AttackButtonClicked()
    {
        // �����ɍU���̏�������������
    }
}
