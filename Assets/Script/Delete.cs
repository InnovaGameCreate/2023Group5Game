using UnityEngine;

public class Delete : MonoBehaviour
{
    public float targetZ = 10.0f; // ���B���ׂ�Z���W

    private void Update()
    {
        // ���݂̃I�u�W�F�N�g��Z���W���ڕWZ���W�ɒB�����ꍇ
        if (transform.position.z >= targetZ)
        {
            // �I�u�W�F�N�g���A�N�e�B�u�ɂ���i������j
            gameObject.SetActive(false);
        }
    }
}
