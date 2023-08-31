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

                //�����ł̈ړ�
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
                //�󒆂ł̈ړ�
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
                Debug.Log("�V�[�������[�h����܂�");
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
            //�G�A�X�g�[���̏��ʉ߂���Ɖ�������
            Debug.Log("�G�A�X�g�[���̏��ʉ߂��܂���");

            Acceleration += AirstoneAcceleration;
            Vector3 upAcceleration = transform.up * upaccelerationAmount;
            rb.AddForce(upAcceleration, ForceMode.Acceleration);
        }
    }

    void FixedUpdate()
    {
        //��������o�����Ƃ𔻒肵�CPlayer�ɏd�͂�^����
        if (!isGravityActive && transform.position.y > targetY || !isGravityActive && transform.position.z > targetZ)
        {
            Debug.Log("��������o�܂���");
            isGravityActive = true;
            rb.useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�ǂɂԂ���ƒ�~����
        if (!isStuck && collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("�ǂɂԂ���܂���");
            isStuck = true;
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //���ɂԂ���ƌ�������
        if (other.CompareTag("Fish"))
        {
            Debug.Log("���ɂԂ���܂���");

            if (AutoMoveSpeed > 0)
            {
                Acceleration -= FishDeceleration;
            }
        }
    }
}
