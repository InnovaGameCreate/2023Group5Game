using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float InitialVelocity;
    [SerializeField] private float InitialAcceleration;
    [SerializeField] private float FishDeceleration;
    [SerializeField] private float targetY;
    [SerializeField] private float targetZ;
    [SerializeField] private float upaccelerationAmount;
    [SerializeField] private float AirstoneAcceleration;
    [SerializeField] private float WaterMoveSpeed;
    [SerializeField] private float AirMoveSpeed;
    [SerializeField] private float xMax;
    [SerializeField] private float xMin;
    [SerializeField] private float yMax;
    [SerializeField] private float yMin;
    private Rigidbody rb;
    private bool isGravityActive = false;
    private bool isStuck = false;
    public Transform airstoneTransform;
    int Round;
    float AutoMoveSpeed;
    float Acceleration;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Round = 1;
        AutoMoveSpeed = InitialVelocity;
        Acceleration = InitialAcceleration;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStuck)
        {
            rb.velocity = new Vector3(0, 0, AutoMoveSpeed);

            if(AutoMoveSpeed < 0)
            {
                AutoMoveSpeed = InitialVelocity;
                Acceleration = InitialAcceleration;
            }

            if (!isGravityActive)
            {
                AutoMoveSpeed += Acceleration * Time.deltaTime;

                //水中での移動
                if (Input.GetKey(KeyCode.A) && this.transform.position.x > xMin)
                    transform.Translate(new Vector3(-WaterMoveSpeed, 0, 0) * Time.deltaTime);
                if (Input.GetKey(KeyCode.D) && this.transform.position.x < xMax)
                    transform.Translate(new Vector3(WaterMoveSpeed, 0, 0) * Time.deltaTime); 
                if (Input.GetKey(KeyCode.W) && this.transform.position.y < yMax)
                    transform.Translate(new Vector3(0, WaterMoveSpeed, 0) * Time.deltaTime); 
                if (Input.GetKey(KeyCode.S) && this.transform.position.y > yMin)
                    transform.Translate(new Vector3(0, -WaterMoveSpeed, 0) * Time.deltaTime); 
            }
            else
            {
                //空中での移動
                if (Input.GetKey(KeyCode.A) && this.transform.position.x > xMin)
                    transform.Translate(new Vector3(-AirMoveSpeed, 0, 0) * Time.deltaTime);
                if (Input.GetKey(KeyCode.D) && this.transform.position.x < xMax)
                    transform.Translate(new Vector3(AirMoveSpeed, 0, 0) * Time.deltaTime);
                if (Input.GetKey(KeyCode.W) && this.transform.position.y < yMax)
                    transform.Translate(new Vector3(0, AirMoveSpeed, 0) * Time.deltaTime);
                if (Input.GetKey(KeyCode.S) && this.transform.position.y > yMin)
                    transform.Translate(new Vector3(0, -AirMoveSpeed, 0) * Time.deltaTime);
            }
        }
        else
        {
            Round++;
            if(Input.GetKey(KeyCode.Return))
            {
                Debug.Log("シーンがロードされます");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        float playerX = transform.position.x;
        float playerZ = transform.position.z;
        float airstoneX = airstoneTransform.position.x;
        float airstoneZ = airstoneTransform.position.z;

        if (!isStuck && playerX >= airstoneX - 0.5f && playerX <= airstoneX + 0.5f &&
            playerZ >= airstoneZ - 0.5f && playerZ <= airstoneZ + 0.5f)
        {
            //エアストーンの上を通過すると加速する
            Debug.Log("エアストーンの上を通過しました");

            Acceleration += AirstoneAcceleration;
            Vector3 upAcceleration = transform.up * upaccelerationAmount;
            rb.AddForce(upAcceleration, ForceMode.Acceleration);
        }
    }

    void FixedUpdate()
    {
        //水槽から出たことを判定し，Playerに重力を与える
        if (!isGravityActive && transform.position.y > targetY || !isGravityActive && transform.position.z > targetZ)
        {
            Debug.Log("水槽から出ました");
            isGravityActive = true;
            rb.useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //壁にぶつかると停止する
        if (!isStuck && collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("壁にぶつかりました");
            isStuck = true;
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //魚にぶつかると減速する
        if (other.CompareTag("Fish"))
        {
            Debug.Log("魚にぶつかりました");

            if (AutoMoveSpeed > 0)
            {
                Acceleration -= FishDeceleration;
            }
        }
    }
}
