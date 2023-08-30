using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yfishmove : MonoBehaviour
{
    [SerializeField] private int MoveSpeed;

    [SerializeField]
    private int stopZPosition = 10; // 整数値に変更
    private bool shouldMove = true;

    private void Update()
    {
        if (shouldMove)
        {
            // オブジェクトの移動
            transform.Translate(new Vector3(0, 0, MoveSpeed) * Time.deltaTime);

            // 指定のZ座標に到達したら移動を停止
            if (transform.position.z >= stopZPosition)
            {
                shouldMove = false;

                // 正確な整数座標にオブジェクトを移動
                transform.position = new Vector3(transform.position.x, transform.position.y, stopZPosition);

                Debug.Log("到達");
            }
        }
    }
}
