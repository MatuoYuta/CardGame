using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectClickExample : MonoBehaviour, IPointerClickHandler
{
    public GameObject buttonToToggle; // �\��/��\����؂�ւ���{�^��

    private bool canClick = false; // �N���b�N�������邩�ǂ����̃t���O

    // �N���b�N���ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    public void OnPointerClick(PointerEventData eventData)
    {
        if (canClick)
        {
            // �N���b�N���ꂽ�I�u�W�F�N�g��Player_field��ɂ���card�I�u�W�F�N�g�ł��邩�`�F�b�N
            if (transform.IsChildOf(GameObject.Find("Player_field").transform) && transform.CompareTag("Card"))
            {
                // �{�^����null�łȂ���΁A�\��/��\����؂�ւ���
                if (buttonToToggle != null)
                {
                    // �{�^���̕\����Ԃ𔽓]������
                    buttonToToggle.SetActive(!buttonToToggle.activeSelf);

                    // �\��/��\����؂�ւ������Ƃ��R���\�[���ɕ\��
                    if (buttonToToggle.activeSelf)
                    {
                        print($"�I�u�W�F�N�g {name} ���N���b�N���ꂽ��I�{�^�����\������܂����B");
                    }
                    else
                    {
                        print($"�I�u�W�F�N�g {name} ���N���b�N���ꂽ��I�{�^������\���ɂȂ�܂����B");
                    }
                }
            }
        }
    }

    // BATTLE�t�F�[�Y�ɓ������Ƃ��ɌĂяo����郁�\�b�h
    public void EnterBattlePhase()
    {
        canClick = true; // �N���b�N��������
    }

    // BATTLE�t�F�[�Y����o���Ƃ��ɌĂяo����郁�\�b�h
    public void ExitBattlePhase()
    {
        canClick = false; // �N���b�N���֎~����

        // �{�^�����\������Ă���ꍇ�͔�\���ɂ���
        if (buttonToToggle != null && buttonToToggle.activeSelf)
        {
            buttonToToggle.SetActive(false);
            print($"BATTLE�t�F�[�Y����o���̂ŁA�{�^�����\���ɂ��܂����B");
        }
    }
}
