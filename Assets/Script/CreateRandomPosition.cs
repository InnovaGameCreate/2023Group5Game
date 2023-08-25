using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("生成するGameObject")]
    private GameObject createPrefab;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;

    [SerializeField]
    [Tooltip("オブジェクトの移動スピード")]
    private float moveSpeed = 5.0f;

    [SerializeField]
    [Tooltip("オブジェクトが消えるまでの時間")]
    private float objectLifetime = 10.0f;

    private float time; // 経過時間

    // Update is called once per frame
    void Update()
    {
        // 前フレームからの時間を加算していく
        time = time + Time.deltaTime;

        // 約1秒置きにランダムに生成されるようにする。
        if (time > 1.0f)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            // GameObjectを上記で決まったランダムな場所に生成
            GameObject createdObject = Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);

            // オブジェクトを移動させる
            MoveObject(createdObject);

            // 一定時間後にオブジェクトを削除する
            Destroy(createdObject, objectLifetime);

            // 経過時間リセット
            time = 0f;
        }

    }

    private void MoveObject(GameObject obj)
    {
        // オブジェクトが Rigidbody コンポーネントを持っているかチェック
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Rigidbody がある場合、velocity を設定して移動
            rb.velocity = Vector3.right * moveSpeed;
        }
        else
        {
            // Rigidbody がない場合、Transform コンポーネントを操作して移動
            obj.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }
}

