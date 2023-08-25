using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��������GameObject")]
    private GameObject createPrefab;
    [SerializeField]
    [Tooltip("��������͈�A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform rangeB;

    [SerializeField]
    [Tooltip("�I�u�W�F�N�g�̈ړ��X�s�[�h")]
    private float moveSpeed = 5.0f;

    [SerializeField]
    [Tooltip("�I�u�W�F�N�g��������܂ł̎���")]
    private float objectLifetime = 10.0f;

    private float time; // �o�ߎ���

    // Update is called once per frame
    void Update()
    {
        // �O�t���[������̎��Ԃ����Z���Ă���
        time = time + Time.deltaTime;

        // ��1�b�u���Ƀ����_���ɐ��������悤�ɂ���B
        if (time > 1.0f)
        {
            // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
            GameObject createdObject = Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);

            // �I�u�W�F�N�g���ړ�������
            MoveObject(createdObject);

            // ��莞�Ԍ�ɃI�u�W�F�N�g���폜����
            Destroy(createdObject, objectLifetime);

            // �o�ߎ��ԃ��Z�b�g
            time = 0f;
        }

    }

    private void MoveObject(GameObject obj)
    {
        // �I�u�W�F�N�g�� Rigidbody �R���|�[�l���g�������Ă��邩�`�F�b�N
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Rigidbody ������ꍇ�Avelocity ��ݒ肵�Ĉړ�
            rb.velocity = Vector3.right * moveSpeed;
        }
        else
        {
            // Rigidbody ���Ȃ��ꍇ�ATransform �R���|�[�l���g�𑀍삵�Ĉړ�
            obj.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }
}

