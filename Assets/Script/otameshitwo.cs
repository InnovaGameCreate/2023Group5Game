using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otameshitwo : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    private void Update()
    {
        // xŽ²•ûŒü‚Éˆê’è‘¬“x‚ÅˆÚ“®‚³‚¹‚é
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
}
