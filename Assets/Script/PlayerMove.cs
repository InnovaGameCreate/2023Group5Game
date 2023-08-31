using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float AutoMoveSpeed;
    [SerializeField] private float FishForce;
    [SerializeField] private float targetY;
    [SerializeField] private float targetZ;
    [SerializeField] private float upaccelerationAmount;
    [SerializeField] private float forwardaccelerationAmount;
    [SerializeField]
    private float WaterMoveSpeed;
    private float AirMoveSpeed;
    [SerializeField] private float xMax;
    [SerializeField] private float xMin;
    [SerializeField] private float yMax;
    [SerializeField] private float yMin;
    private Rigidbody rb;
    private bool isGravityActive = false;
    private bool isStuck = false;
    public Transform airstoneTransform;
    int Round; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Round = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStuck)
        {
            rb.velocity = new Vector3(0, 0, AutoMoveSpeed);

            if (!isGravityActive)
            {
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
            if(Round <= 3 && Input.GetKey(KeyCode.Return))
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

            Vector3 upAcceleration = transform.up * upaccelerationAmount;
            Vector3 forwardAcceleration = transform.forward * forwardaccelerationAmount;
            Vector3 totalAcceleration = upAcceleration + forwardAcceleration;
            rb.AddForce(totalAcceleration, ForceMode.Acceleration);
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
            Vector3 force = -transform.forward * FishForce;
            rb.AddForce(force, ForceMode.Acceleration);
        }
    }
}
