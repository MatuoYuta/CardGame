using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    // �U���{�^��
    public Button attackButton;

    // �J�[�h���I�����ꂽ�Ƃ��ɌĂ΂��֐�
    public void OnCardSelected()
    {
        // �J�[�h���I�����ꂽ�ꍇ�A�U���{�^����\������
        attackButton.gameObject.SetActive(true);
    }
}
