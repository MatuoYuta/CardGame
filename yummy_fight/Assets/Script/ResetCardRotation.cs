using UnityEngine;

public class ResetCardRotation : MonoBehaviour
{
    // StandbyPhase���ɌĂяo�����֐�
    public void OnStandbyPhase()
    {
        // Player_field�̎q�v�f���ׂĂɑ΂��ď������s��
        foreach (Transform cardTransform in transform)
        {
            // �J�[�h��Transform�R���|�[�l���g��rotation�����Z�b�g����
            cardTransform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}
