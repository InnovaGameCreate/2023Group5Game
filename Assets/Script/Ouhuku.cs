using UnityEngine;

public class Ouhuku : MonoBehaviour
{
    public float movementRange = 5.0f; // �ړ��͈�
    public float movementSpeed = 2.0f; // �ړ����x

    private Vector3 startingPosition;
    private bool movingUp = true;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        // �I�u�W�F�N�g�̌��݈ʒu���擾
        Vector3 currentPosition = transform.position;

        // �㉺�ړ�����
        if (movingUp)
        {
            // ��Ɉړ����̏���
            if (currentPosition.z < startingPosition.z + movementRange)
            {
                // ������Ɉړ�
                currentPosition.z += movementSpeed * Time.deltaTime;
            }
            else
            {
                // �ړ��͈͂̏���ɒB�����牺�Ɉړ��J�n
                movingUp = false;
            }
        }
        else
        {
            // ���Ɉړ����̏���
            if (currentPosition.z > startingPosition.z - movementRange)
            {
                // �������Ɉړ�
                currentPosition.z -= movementSpeed * Time.deltaTime;
            }
            else
            {
                // �ړ��͈͂̉����ɒB�������Ɉړ��J�n
                movingUp = true;
            }
        }

        // �V�����ʒu��ݒ�
        transform.position = currentPosition;
    }
}

