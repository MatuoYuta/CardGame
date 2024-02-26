using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectClickExample : MonoBehaviour, IPointerClickHandler
{
    public GameObject buttonToToggle; // �\��/��\����؂�ւ���{�^��

    // �N���b�N���ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    public void OnPointerClick(PointerEventData eventData)
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

