using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yfishmove : MonoBehaviour
{
    [SerializeField] private int MoveSpeed;

    [SerializeField]
    private int stopZPosition = 10; // �����l�ɕύX
    private bool shouldMove = true;

    private void Update()
    {
        if (shouldMove)
        {
            // �I�u�W�F�N�g�̈ړ�
            transform.Translate(new Vector3(0, 0, MoveSpeed) * Time.deltaTime);

            // �w���Z���W�ɓ��B������ړ����~
            if (transform.position.z >= stopZPosition)
            {
                shouldMove = false;

                // ���m�Ȑ������W�ɃI�u�W�F�N�g���ړ�
                transform.position = new Vector3(transform.position.x, transform.position.y, stopZPosition);

                Debug.Log("���B");
            }
        }
    }
}
