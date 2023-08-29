using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fishPrefabs; // 魚のプレハブを格納する配列

    [SerializeField]
    private Transform spawnPoint; // 魚の生成位置

    [SerializeField]
    private float minSpawnInterval = 1.0f; // 最小生成間隔
    [SerializeField]
    private float maxSpawnInterval = 3.0f; // 最大生成間隔

    private float spawnTimer = 0f;

    private void Update()
    {
        // タイマーを更新
        spawnTimer -= Time.deltaTime;

        // タイマーが0以下になったら魚を生成
        if (spawnTimer <= 0f)
        {
            SpawnRandomFish();
            // 新たなランダムな生成間隔を設定
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

        int randomIndex = Random.Range(0, fishPrefabs.Length); // ランダムなインデックスを選択
        GameObject selectedFishPrefab = fishPrefabs[randomIndex]; // 選ばれた魚のプレハブを取得

        // 指定した位置に魚を生成
        GameObject spawnedFish = Instantiate(selectedFishPrefab, spawnPoint.position, Quaternion.identity);

        // 任意の追加処理をここに追加可能

        Debug.Log("Spawned fish: " + selectedFishPrefab.name);
    }
}
