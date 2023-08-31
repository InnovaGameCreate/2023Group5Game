using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otameshi : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fishPrefabs; // 魚のプレハブを格納する配列

    [SerializeField]
    private Transform rangeA;
    [SerializeField]
    private Transform rangeB;

    [SerializeField]
    private float spawnInterval = 1.0f; // 生成間隔

    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private float objectLifetime = 10.0f; // オブジェクトの寿命（生存時間）の設定


    private float spawnTimer = 0.0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnRandomFish();
            spawnTimer = 0.0f; // タイマーリセット
        }


    }

    private void SpawnRandomFish()
    {
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        int randomFishIndex = Random.Range(0, fishPrefabs.Length); // ランダムな魚の種類を選択
        GameObject randomFishPrefab = fishPrefabs[randomFishIndex];

        GameObject newFish = Instantiate(randomFishPrefab, new Vector3(x, y, z), randomFishPrefab.transform.rotation);

        MoveObject(newFish);

        Destroy(newFish, objectLifetime); // objectLifetime は事前に定義しておく必要があります
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
