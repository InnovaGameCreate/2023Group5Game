using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float xSpeed;
    [SerializeField] public float ySpeed;
    [SerializeField] public float zSpeed;
    [SerializeField] private float targetY;
    private Rigidbody rb;
    private bool isGravityActive = false;
    private bool isStuck = false;
    private int boardCollisionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Playerが設定の高さから放物運動をする
        if (!isGravityActive && transform.position.y > targetY)
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isStuck && collision.gameObject.tag == "Board")
        {
            isStuck = true;
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            // Boardにぶつかった回数をカウント
            boardCollisionCount++;

            // 3回ぶつかったら現在のシーンを再読み込み
            if (boardCollisionCount >= 3)
            {
                // 現在のSceneを取得
                Scene loadScene = SceneManager.GetActiveScene();
                // 現在のシーンを再読み込みする
                SceneManager.LoadScene(loadScene.buildIndex);
            }
        }
    }
}