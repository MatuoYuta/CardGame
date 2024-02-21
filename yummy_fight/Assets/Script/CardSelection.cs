using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    public GameObject attackButton;

    public bool cardSelected = false;

    void Start()
    {
        // �ŏ��͍U���{�^�����\���ɂ���
        attackButton.gameObject.SetActive(false);
    }

    void Update()
    {
        // �}�E�X�̍��N���b�N�������ꂽ���ǂ������m�F���A�J�[�h���N���b�N���ꂽ�ꍇ�Ƀt���O��ݒ肷��
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 ray2D = new Vector2(ray.origin.x, ray.origin.y);
            RaycastHit2D hit2D = Physics2D.Raycast(ray2D, Vector2.zero);
            if (hit2D.collider != null && hit2D.collider.gameObject.CompareTag("Card"))
            {
                cardSelected = (true);
            }
        }

        // �J�[�h���I������Ă��邩�ǂ������m�F���A�U���{�^���̕\����Ԃ��X�V����
        if (cardSelected)
        {
            attackButton.gameObject.SetActive(true);
        }
        else
        {
            attackButton.gameObject.SetActive(false);
        }
    }
}