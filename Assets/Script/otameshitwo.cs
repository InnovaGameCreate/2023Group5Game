using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otameshitwo : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    private void Update()
    {
        // x�������Ɉ�葬�x�ňړ�������
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
}
