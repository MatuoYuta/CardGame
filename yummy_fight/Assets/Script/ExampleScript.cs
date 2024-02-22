using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public Camera camera;

    void Start()
    {
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            Transform objectHit = hit.transform;
            // ���C�ɓ��������I�u�W�F�N�g�ɉ���������
            if (objectHit.CompareTag("Card"))
            {
                // �J�[�h�I�u�W�F�N�g�ɃA�^�b�`����Ă���ButtonExample�X�N���v�g���擾
                ButtonExample buttonExample = objectHit.GetComponent<ButtonExample>();

                // ButtonExample�X�N���v�g�����݂��A�L���ł���Ώ������Ăяo��
                if (buttonExample != null && buttonExample.enabled)
                {
                    buttonExample.ButtonClicked();
                }
            }
        }
    }
}
