using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public GameObject cardObject; // �������ɂ���Card�I�u�W�F�N�g
    private Quaternion originalRotation; // ���̉�]��ۑ�����ϐ�
    private bool isRotated = false; // �J�[�h����]���Ă��邩�ǂ����������t���O
    private Coroutine rotateCoroutine; // ��]���Ǘ�����R���[�`��

    private void Start()
    {
        // �J�[�h�I�u�W�F�N�g�̌��̉�]��ۑ�
        originalRotation = cardObject.transform.rotation;
    }

    public void OnAttackButtonClick()
    {
        Debug.Log("����ɍU������");
        RotateCard(); // �J�[�h���������ɂ��郁�\�b�h���Ăяo��
    }

    void RotateCard()
    {
        // �J�[�h��90�x��]������
        cardObject.transform.Rotate(new Vector3(0f, 0f, 90f));
        isRotated = true; // �J�[�h����]���Ă��邱�Ƃ������t���O��true�ɐݒ�
        // �R���[�`�����J�n
        rotateCoroutine = StartCoroutine(ReturnToOriginalRotation());
    }

    IEnumerator ReturnToOriginalRotation()
    {
        // ��莞�ԑ҂i�X�^���o�C�t�F�[�Y��z��j
        yield return new WaitForSeconds(2f);

        // �J�[�h����]���Ă���ꍇ�͌��̌����ɖ߂�
        if (isRotated)
        {
            // �J�[�h�I�u�W�F�N�g�̉�]�����ɖ߂�
            cardObject.transform.rotation = originalRotation;
            isRotated = false; // �J�[�h����]���Ă��Ȃ����Ƃ������t���O��false�ɐݒ�
        }
    }

    // �R���[�`�����~���郁�\�b�h
    private void StopRotateCoroutine()
    {
        if (rotateCoroutine != null)
        {
            StopCoroutine(rotateCoroutine);
        }
    }

    private void OnDestroy()
    {
        StopRotateCoroutine(); // �I�u�W�F�N�g���j�������ۂɃR���[�`�����~����
    }
}
