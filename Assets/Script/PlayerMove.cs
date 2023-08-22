using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    [SerializeField] private float zSpeed;
    [SerializeField] private float targetY;
    private Rigidbody rb;
    private bool isGravityActive = false;
    private bool isStuck = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (isStuck)
        {
            rb.velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGravityActive && transform.position.y> targetY)
        {
            isGravityActive = true;
            rb.useGravity = true;
        }

        if (isStuck)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            transform.Translate(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isStuck && collision.gameObject.tag == "Board")
        {
            isStuck = true;
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
