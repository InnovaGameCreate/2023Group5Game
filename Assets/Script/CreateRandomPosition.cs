using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject createPrefab;
    [SerializeField]
    private Transform rangeA;
    [SerializeField]
    private Transform rangeB;

    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float objectLifetime = 10.0f;
    [SerializeField]
    private float stopZPosition = 10.0f;
    private int roundedZ;

    private float time;

    private void Awake()
    {
        roundedZ = Mathf.RoundToInt(stopZPosition);
    }

    void Update()
    {
        // Z座標が指定位置に到達したらオブジェクトの生成を止める
        if (this.transform.position.z < stopZPosition)
        {
            // 約1秒置きにランダムに生成されるようにする。

            time += Time.deltaTime;
            if (time > 1.0f)
            {
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                float y = Random.Range(rangeA.position.y, rangeB.position.y);
                float z = Random.Range(rangeA.position.z, rangeB.position.z);

                GameObject createdObject = Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);

                MoveObject(createdObject);
                Destroy(createdObject, objectLifetime);

                time = 0f;
            }
        }
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
