using UnityEngine;
using UnityEngine.UI;

public class ButtonExample : MonoBehaviour
{
    public GameObject button;

    void Start()
    {
        // Button�̃C���X�^���X���擾���āA��\���ɐݒ肷��
        button.gameObject.SetActive(false);
    }

    // �{�^�����N���b�N���ꂽ�Ƃ��Ɏ��s����郁�\�b�h
    public void ButtonClicked()
    {
        Debug.Log("Button clicked!");
    }

    // �I�u�W�F�N�g���I�����ꂽ�Ƃ��Ɏ��s����郁�\�b�h
    private void OnMouseDown()
    {
        // �{�^����\������
        button.gameObject.SetActive(true);
    }
}