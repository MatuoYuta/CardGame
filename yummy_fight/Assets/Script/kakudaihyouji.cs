using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class kakudaihyouji : MonoBehaviour, IPointerClickHandler
{
    public string targetTag = "Card"; // �g��\������I�u�W�F�N�g�̃^�O
    public RectTransform targetPanel; // �g��\������p�l��
    public GameObject currentObjectInstance; // ���ݕ\������Ă���I�u�W�F�N�g�̃C���X�^���X

    void Start()
    {
        // kakudai �p�l�����������ĎQ�Ƃ���
        GameObject kakudaiPanel = GameObject.Find("kakudai");
        if (kakudaiPanel != null)
        {
            targetPanel = kakudaiPanel.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogError("kakudai �p�l����������܂���ł����B");
        }

        // �V�[����EventSystem���Ȃ��ꍇ�͒ǉ�����
        if (FindObjectOfType<EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }

    // �N���b�N���ꂽ�Ƃ��̏���
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerPress;
        if (clickedObject != null && clickedObject.CompareTag(targetTag))
        {
            // �g��\������I�u�W�F�N�g���N���b�N���ꂽ�ꍇ
            if (currentObjectInstance == null)
            {
                currentObjectInstance = clickedObject;
                currentObjectInstance.transform.SetParent(targetPanel); // �g��\������p�l���̎q�ɂ���
                currentObjectInstance.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // �p�l���̒����ɔz�u
                currentObjectInstance.GetComponent<RectTransform>().localScale = Vector3.one * 1.5f; // 1.5�{�̃T�C�Y�Ɋg��
            }
            else
            {
                Destroy(currentObjectInstance); // ���łɕ\������Ă���ꍇ�͍폜
                currentObjectInstance = null;
            }
        }
        else
        {
            // �g��\������I�u�W�F�N�g�ȊO���N���b�N���ꂽ�ꍇ
            if (currentObjectInstance != null)
            {
                Destroy(currentObjectInstance); // �g��\��������
                currentObjectInstance = null;
            }
        }
    }
}
