using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yfishmove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, MoveSpeed, 0) * Time.deltaTime);
    }
}