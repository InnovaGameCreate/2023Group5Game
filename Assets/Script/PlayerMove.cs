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

            if (Input.GetKey(KeyCode.A) && this.transform.position.x > xMin)//A����������ړ��A���I�u�W�F�N�g��x���W��xMin�ȏ�̒l�Ȃ�ړ��\
                transform.Translate(new Vector3(-MoveSpeed, 0, 0) * Time.deltaTime); //�ړ����邽�߂̃v���O����

            if (Input.GetKey(KeyCode.D) && this.transform.position.x < xMax)//D����������ړ��A���I�u�W�F�N�g��x���W��xMax�ȉ��̒l�Ȃ�ړ��\
                transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime); //�ړ����邽�߂̃v���O����

            if (Input.GetKey(KeyCode.W) && this.transform.position.y < yMax)//W����������ړ��A���I�u�W�F�N�g��z���W��zMax�ȉ��̒l�Ȃ�ړ��\
                transform.Translate(new Vector3(0, MoveSpeed, 0) * Time.deltaTime); //�ړ����邽�߂̃v���O����

            if (Input.GetKey(KeyCode.S) && this.transform.position.y > yMin)//S����������ړ��A���I�u�W�F�N�g��z���W��xMin�ȏ�̒l�Ȃ�ړ��\
                transform.Translate(new Vector3(0, -MoveSpeed, 0) * Time.deltaTime); //�ړ����邽�߂̃v���O����
        }

        float playerX = transform.position.x;
        float playerZ = transform.position.z;
        float airstoneX = airstoneTransform.position.x;
        float airstoneZ = airstoneTransform.position.z;

        if (!isStuck && playerX >= airstoneX - 0.5f && playerX <= airstoneX + 0.5f &&
            playerZ >= airstoneZ - 0.5f && playerZ <= airstoneZ + 0.5f)
        {
            Debug.Log("�G�A�X�g�[���̏��ʉ߂��܂���");

            Vector3 upAcceleration = transform.up * upaccelerationAmount; // �����x�N�g�����g���K�[�]�[���̏�����ɐݒ�
            Vector3 forwardAcceleration = transform.forward * forwardaccelerationAmount;
            Vector3 totalAcceleration = upAcceleration + forwardAcceleration;
            rb.AddForce(totalAcceleration, ForceMode.Acceleration);
        }
    }

    void FixedUpdate()
    {
        if (!isGravityActive && transform.position.y > targetY || !isGravityActive && transform.position.z > targetZ)
        {
            Debug.Log("��������o�܂���");
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
            Debug.Log("���ɂԂ���܂���");
            Vector3 force = new Vector3(-xFishForce, -yFishForce, -zFishForce);
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
}
