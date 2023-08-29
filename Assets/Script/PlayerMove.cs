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
        // Playerが設定の高さから放物運動をする
        if (!isGravityActive && transform.position.y > targetY || !isGravityActive && transform.position.z > targetZ)
        {
            isGravityActive = true;
            rb.useGravity = true;
        }

        if (isStuck)
        {
            // Boardに当たると止まる
            rb.velocity = Vector3.zero;
        }
        else
        {
            // Playerを自動で進ませる
            transform.Translate(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime);
        }

        // Playerの現在のxおよびz座標を取得
        float playerX = transform.position.x;
        float playerZ = transform.position.z;

        // Airstoneのxおよびz座標を取得
        float airstoneX = airstoneTransform.position.x;
        float airstoneZ = airstoneTransform.position.z;

        // PlayerがAirstoneのxおよびz座標上を通過した場合に加速する
        if (playerX == airstoneX && playerZ == airstoneZ)
        {
            Debug.Log("エアストーンの上を通過しました");
            Vector3 force = new Vector3(xAirstoneForce, yAirstoneForce, zAirstoneForce);  // 力を設定
            rb.AddForce(force, ForceMode.Impulse);          // 力を加える
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
                // SceneChangeスクリプトを持つゲームオブジェクトのSceneChangeコンポーネントを取得して、LoadEndSceneメソッドを呼び出す
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
            Vector3 force = new Vector3(-xFishForce, -yFishForce, -zFishForce);  // 力を設定
            rb.AddForce(force, ForceMode.Impulse);          // 力を加える
        }
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
