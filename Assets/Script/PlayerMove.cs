using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float xSpeed;
    [SerializeField] public float ySpeed;
    [SerializeField] public float zSpeed;
    [SerializeField] public float xAirstoneForce;
    [SerializeField] public float yAirstoneForce;
    [SerializeField] public float zAirstoneForce;
    [SerializeField] public float xFishForce;
    [SerializeField] public float yFishForce;
    [SerializeField] public float zFishForce;
    [SerializeField] private float targetY;
    [SerializeField] private float targetZ;
    [SerializeField] private float accelerationAmount;
    private Rigidbody rb;
    private bool isGravityActive = false;
    private bool isStuck = false;
    public Transform airstoneTransform;
    private int boardCollisionCount = 0;
    private const int MaxBoardCollisions = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player���ݒ�̍�����������^��������
        if (!isGravityActive && transform.position.y > targetY || !isGravityActive && transform.position.z > targetZ)
        {
            isGravityActive = true;
            rb.useGravity = true;
        }

        if (isStuck)
        {
            // Board�ɓ�����Ǝ~�܂�
            rb.velocity = Vector3.zero;
        }
        else
        {
            // Player�������Ői�܂���
            transform.Translate(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime);
        }

        // Player�̌��݂�x�����z���W���擾
        float playerX = transform.position.x;
        float playerZ = transform.position.z;

        // Airstone��x�����z���W���擾
        float airstoneX = airstoneTransform.position.x;
        float airstoneZ = airstoneTransform.position.z;

        // Player��Airstone��x�����z���W���ʉ߂����ꍇ�ɉ�������
        if (playerX == airstoneX && playerZ == airstoneZ)
        {
            Debug.Log("�G�A�X�g�[���̏��ʉ߂��܂���");
            Vector3 force = new Vector3(xAirstoneForce, yAirstoneForce, zAirstoneForce);  // �͂�ݒ�
            rb.AddForce(force, ForceMode.Impulse);          // �͂�������
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isStuck && collision.gameObject.tag == "Board")
        {
            isStuck = true;
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            boardCollisionCount++;

            if (boardCollisionCount >= MaxBoardCollisions)
            {
                // SceneChange�X�N���v�g�����Q�[���I�u�W�F�N�g��SceneChange�R���|�[�l���g���擾���āALoadEndScene���\�b�h���Ăяo��
                SceneChange sceneChangeScript = FindObjectOfType<SceneChange>();
                if (sceneChangeScript != null)
                {
                    sceneChangeScript.LoadEndScene();
                }
            }
            else
            {
                ReloadCurrentScene();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            Debug.Log("���ɂԂ���܂���");
            Vector3 force = new Vector3(-xFishForce, -yFishForce, -zFishForce);  // �͂�ݒ�
            rb.AddForce(force, ForceMode.Impulse);          // �͂�������
        }
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
