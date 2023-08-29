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
        // Player�̌��݂�x�����z���W���擾
        float playerX = transform.position.x;
        float playerZ = transform.position.z;

        // Airstone��x�����z���W���擾
        float airstoneX = airstoneTransform.position.x;
        float airstoneZ = airstoneTransform.position.z;

        // Player��Cube��x�����z���W���ʉ߂����ꍇ�ɉ�������
        if (playerX == airstoneX && playerZ == airstoneZ)
        {
            // Player��Rigidbody���擾���ĉ�������
            Rigidbody playerRigidbody = GetComponent<Rigidbody>();
            playerRigidbody.velocity += Vector3.up * accelerationAmount;
        }
    }
}
