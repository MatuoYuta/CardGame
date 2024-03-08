using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    private RectTransform targetPanel; // �g��\������摜���\�������p�l��
    private GameObject currentCard; // ���ݕ\������Ă���J�[�h�̃C���X�^���X
    private const float ScaleFactor = 3f; // �摜�̊g��{��

    void Start()
    {
        // Kakudai �p�l�����������ĎQ�Ƃ���
        GameObject kakudaiPanel = GameObject.Find("Kakudai");
        if (kakudaiPanel != null)
        {
            targetPanel = kakudaiPanel.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogError("Kakudai Panel not found!");
        }

        // �V�[����EventSystem���Ȃ��ꍇ�͒ǉ�����
        if (FindObjectOfType<EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }

    // �N���b�N���ꂽ�Ƃ��ɌĂ΂��֐�
    public void OnPointerClick(PointerEventData eventData)
    {
        // �N���b�N���ꂽ�ꏊ�ɃI�u�W�F�N�g�����邩�`�F�b�N
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            // �N���b�N���ꂽ�I�u�W�F�N�g��Card�^�O�������Ă��邩�`�F�b�N
            if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Card"))
            {
                // �N���b�N���ꂽ�I�u�W�F�N�g�Ɋ��蓖�Ă��Ă���Image�R���|�[�l���g���擾
                Image cardImage = eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>();
                if (cardImage != null)
                {
                    Debug.Log("����");
                    // ������CardPreview�����݂���ꍇ�͍폜����
                    DestroyCurrentCardPreview();

                    // �g��\������摜��Prefab�𐶐�
                    currentCard = new GameObject("CardPreview");
                    currentCard.transform.SetParent(targetPanel, false);
                    currentCard.tag = "kakudai";

                    // �������ꂽPrefab�ɃN���b�N���ꂽ�I�u�W�F�N�g�̉摜��ݒ�
                    Image targetImage = currentCard.AddComponent<Image>();
                    targetImage.sprite = cardImage.sprite;

                    // �摜�̑傫����3�{�ɂ���
                    RectTransform rectTransform = currentCard.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = new Vector2(cardImage.rectTransform.sizeDelta.x * 9f, cardImage.rectTransform.sizeDelta.y * 1.8f);
                }
                Debug.Log("�����I��");
            }
            else
            {
                Debug.Log("�^�O�Ȃ�");
                // kakudai�^�O�̂����I�u�W�F�N�g��j��
                DestroyCurrentCardPreview();
            }
        }
        else
        {
            Debug.Log("�I�u�W�F�N�g�Ȃ�");
            // kakudai�^�O�̂����I�u�W�F�N�g��j��
            DestroyCurrentCardPreview();
        }
    }

    // ���݂̃J�[�h�v���r���[���폜���郁�\�b�h
    private void DestroyCurrentCardPreview()
    {
        GameObject[] kakudaiObjects = GameObject.FindGameObjectsWithTag("kakudai");

        foreach (GameObject obj in kakudaiObjects)
        {
            Destroy(obj);
            Debug.Log("�폜����");
        }

        currentCard = null;
    }
}
