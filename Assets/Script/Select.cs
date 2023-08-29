using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fishPrefabs; // ���̃v���n�u���i�[����z��

    [SerializeField]
    private Transform spawnPoint; // ���̐����ʒu

    [SerializeField]
    private float minSpawnInterval = 1.0f; // �ŏ������Ԋu
    [SerializeField]
    private float maxSpawnInterval = 3.0f; // �ő吶���Ԋu

    private float spawnTimer = 0f;

    private void Update()
    {
        // �^�C�}�[���X�V
        spawnTimer -= Time.deltaTime;

        // �^�C�}�[��0�ȉ��ɂȂ����狛�𐶐�
        if (spawnTimer <= 0f)
        {
            SpawnRandomFish();
            // �V���ȃ����_���Ȑ����Ԋu��ݒ�
            spawnTimer = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void SpawnRandomFish()
    {
        if (fishPrefabs.Length == 0)
        {
            Debug.LogError("No fish prefabs assigned!");
            return;
        }

        int randomIndex = Random.Range(0, fishPrefabs.Length); // �����_���ȃC���f�b�N�X��I��
        GameObject selectedFishPrefab = fishPrefabs[randomIndex]; // �I�΂ꂽ���̃v���n�u���擾

        // �w�肵���ʒu�ɋ��𐶐�
        GameObject spawnedFish = Instantiate(selectedFishPrefab, spawnPoint.position, Quaternion.identity);

        // �C�ӂ̒ǉ������������ɒǉ��\

        Debug.Log("Spawned fish: " + selectedFishPrefab.name);
    }
}
