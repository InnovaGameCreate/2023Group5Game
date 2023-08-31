using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otameshi : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fishPrefabs; // ���̃v���n�u���i�[����z��

    [SerializeField]
    private Transform rangeA;
    [SerializeField]
    private Transform rangeB;

    [SerializeField]
    private float spawnInterval = 1.0f; // �����Ԋu

    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private float objectLifetime = 10.0f; // �I�u�W�F�N�g�̎����i�������ԁj�̐ݒ�


    private float spawnTimer = 0.0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnRandomFish();
            spawnTimer = 0.0f; // �^�C�}�[���Z�b�g
        }


    }

    private void SpawnRandomFish()
    {
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        int randomFishIndex = Random.Range(0, fishPrefabs.Length); // �����_���ȋ��̎�ނ�I��
        GameObject randomFishPrefab = fishPrefabs[randomFishIndex];

        GameObject newFish = Instantiate(randomFishPrefab, new Vector3(x, y, z), randomFishPrefab.transform.rotation);

        MoveObject(newFish);

        Destroy(newFish, objectLifetime); // objectLifetime �͎��O�ɒ�`���Ă����K�v������܂�
    }

    private void MoveObject(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.right * moveSpeed;
        }
        else
        {
            obj.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }
}
