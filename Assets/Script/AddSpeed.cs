using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeed : MonoBehaviour
{
    [SerializeField] private float accelerationAmount;
    public Transform airstoneTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Playerの現在のxおよびz座標を取得
        float playerX = transform.position.x;
        float playerZ = transform.position.z;

        // Airstoneのxおよびz座標を取得
        float airstoneX = airstoneTransform.position.x;
        float airstoneZ = airstoneTransform.position.z;

        // PlayerがCubeのxおよびz座標上を通過した場合に加速する
        if (playerX == airstoneX && playerZ == airstoneZ)
        {
            // PlayerのRigidbodyを取得して加速する
            Rigidbody playerRigidbody = GetComponent<Rigidbody>();
            playerRigidbody.velocity += Vector3.up * accelerationAmount;
        }
    }
}
