using UnityEngine;
using UnityEngine.UI;

public class AttackActionPanel : MonoBehaviour
{
    public GameObject blockButton; // �u���b�N����{�^��
    public GameObject lifeButton; // ���C�t�Ŏ󂯂�{�^��

    void Start()
    {
        // ������Ԃł̓{�^�����\���ɂ���
        blockButton.SetActive(false);
        lifeButton.SetActive(false);
    }

    // �{�^����\�����郁�\�b�h
    public void ShowButtons()
    {
        blockButton.SetActive(true);
        lifeButton.SetActive(true);
    }

    // �{�^�����\���ɂ��郁�\�b�h
    public void HideButtons()
    {
        blockButton.SetActive(false);
        lifeButton.SetActive(false);
    }
}
