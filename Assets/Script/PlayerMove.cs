using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float xSpeed;
    [SerializeField] public float ySpeed;
    [SerializeField] public float zSpeed;
    [SerializeField] private float targetY;
    private Rigidbody rb;
    private bool isGravityActive = false;
    private bool isStuck = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerÇ™ê›íËÇÃçÇÇ≥Ç©ÇÁï˙ï®â^ìÆÇÇ∑ÇÈ
        if (!isGravityActive && transform.position.y> targetY)
        {
            isGravityActive = true;
            rb.useGravity = true;
        }

        if (isStuck)
        {
            //BoardÇ…ìñÇΩÇÈÇ∆é~Ç‹ÇÈ
            rb.velocity = Vector3.zero;
        }
        else
        {
            //PlayerÇé©ìÆÇ≈êiÇ‹ÇπÇÈ
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
