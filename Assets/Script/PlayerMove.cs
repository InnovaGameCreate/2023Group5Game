using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float xSpeed;
    [SerializeField] public float ySpeed;
    [SerializeField] public float zSpeed;
    [SerializeField] private float xFishForce;
    [SerializeField] private float yFishForce;
    [SerializeField] private float zFishForce;
    [SerializeField] private float targetY;
    [SerializeField] private float targetZ;
    [SerializeField] private float upaccelerationAmount;
    [SerializeField] private float forwardaccelerationAmount;
    [SerializeField]
    private float MoveSpeed;
    [SerializeField] private float xMax;
    [SerializeField] private float xMin;
    [SerializeField] private float yMax;
    [SerializeField] private float yMin;
    private Rigidbody rb;
    private bool isGravityActive = false;
    private bool isStuck = false;
    public Transform airstoneTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStuck)
        {
            rb.velocity = new Vector3(xSpeed, ySpeed, zSpeed);

            if (Input.GetKey(KeyCode.A) && this.transform.position.x > xMin)//Aを押したら移動、かつオブジェクトのx座標がxMin以上の値なら移動可能
                transform.Translate(new Vector3(-MoveSpeed, 0, 0) * Time.deltaTime); //移動するためのプログラム

            if (Input.GetKey(KeyCode.D) && this.transform.position.x < xMax)//Dを押したら移動、かつオブジェクトのx座標がxMax以下の値なら移動可能
                transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime); //移動するためのプログラム

            if (Input.GetKey(KeyCode.W) && this.transform.position.y < yMax)//Wを押したら移動、かつオブジェクトのz座標がzMax以下の値なら移動可能
                transform.Translate(new Vector3(0, MoveSpeed, 0) * Time.deltaTime); //移動するためのプログラム

            if (Input.GetKey(KeyCode.S) && this.transform.position.y > yMin)//Sを押したら移動、かつオブジェクトのz座標がxMin以上の値なら移動可能
                transform.Translate(new Vector3(0, -MoveSpeed, 0) * Time.deltaTime); //移動するためのプログラム
        }

        float playerX = transform.position.x;
        float playerZ = transform.position.z;
        float airstoneX = airstoneTransform.position.x;
        float airstoneZ = airstoneTransform.position.z;

        if (!isStuck && playerX >= airstoneX - 0.5f && playerX <= airstoneX + 0.5f &&
            playerZ >= airstoneZ - 0.5f && playerZ <= airstoneZ + 0.5f)
        {
            Debug.Log("エアストーンの上を通過しました");

            Vector3 upAcceleration = transform.up * upaccelerationAmount; // 加速ベクトルをトリガーゾーンの上方向に設定
            Vector3 forwardAcceleration = transform.forward * forwardaccelerationAmount;
            Vector3 totalAcceleration = upAcceleration + forwardAcceleration;
            rb.AddForce(totalAcceleration, ForceMode.Acceleration);
        }
    }

    void FixedUpdate()
    {
        if (!isGravityActive && transform.position.y > targetY || !isGravityActive && transform.position.z > targetZ)
        {
            Debug.Log("水槽から出ました");
            isGravityActive = true;
            rb.useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isStuck && collision.gameObject.CompareTag("Wall"))
        {
            isStuck = true;
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            Debug.Log("魚にぶつかりました");
            Vector3 force = new Vector3(-xFishForce, -yFishForce, -zFishForce);
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
}
