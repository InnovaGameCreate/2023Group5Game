using UnityEngine;

public class Ouhuku : MonoBehaviour
{
    public float movementRange = 5.0f; // 移動範囲
    public float movementSpeed = 2.0f; // 移動速度

    private Vector3 startingPosition;
    private bool movingUp = true;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        // オブジェクトの現在位置を取得
        Vector3 currentPosition = transform.position;

        // 上下移動判定
        if (movingUp)
        {
            // 上に移動中の処理
            if (currentPosition.z < startingPosition.z + movementRange)
            {
                // 上方向に移動
                currentPosition.z += movementSpeed * Time.deltaTime;
            }
            else
            {
                // 移動範囲の上限に達したら下に移動開始
                movingUp = false;
            }
        }
        else
        {
            // 下に移動中の処理
            if (currentPosition.z > startingPosition.z - movementRange)
            {
                // 下方向に移動
                currentPosition.z -= movementSpeed * Time.deltaTime;
            }
            else
            {
                // 移動範囲の下限に達したら上に移動開始
                movingUp = true;
            }
        }

        // 新しい位置を設定
        transform.position = currentPosition;
    }
}

