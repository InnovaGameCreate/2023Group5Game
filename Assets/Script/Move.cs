using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private int MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �I�u�W�F�N�g�̈ړ�
        transform.Translate(new Vector3(0, 0, MoveSpeed) * Time.deltaTime);
    }
}
