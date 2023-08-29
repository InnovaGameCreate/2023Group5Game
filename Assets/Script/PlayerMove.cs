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
        if (!isStuck)
        {
            rb.velocity = new Vector3(xSpeed, ySpeed, zSpeed);
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
        if (!isStuck && collision.gameObject.CompareTag("Board"))
        {
            isStuck = true;
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            boardCollisionCount++;

            if (boardCollisionCount >= MaxBoardCollisions)
            {
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
            Debug.Log("魚にぶつかりました");
            Vector3 force = new Vector3(-xFishForce, -yFishForce, -zFishForce);
            rb.AddForce(force, ForceMode.Impulse);
        }
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
