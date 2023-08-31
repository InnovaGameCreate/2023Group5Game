using UnityEngine;

public class Delete : MonoBehaviour
{
    public float targetZ = 10.0f; // 到達すべきZ座標

    private void Update()
    {
        // 現在のオブジェクトのZ座標が目標Z座標に達した場合
        if (transform.position.z >= targetZ)
        {
            // オブジェクトを非アクティブにする（消える）
            gameObject.SetActive(false);
        }
    }
}
