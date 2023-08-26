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

    private const int MaxBoardCollisions = 3;
    private const string EndSceneName = "End";

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleGravityActivation();
        HandleMovement();
    }

    void HandleGravityActivation()
    {
        if (!isGravityActive && transform.position.y > targetY)
        {
            isGravityActive = true;
            rb.useGravity = true;
        }
    }

    void HandleMovement()
    {
        if (isStuck)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            transform.Translate(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isStuck && collision.gameObject.tag == "Board")
        {
            isStuck = true;
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            boardCollisionCount++;

            if (boardCollisionCount >= MaxBoardCollisions)
            {
                LoadEndScene();
            }
            else
            {
                ReloadCurrentScene();
            }
        }
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LoadEndScene()
    {
        SceneManager.LoadScene(EndSceneName);
    }
}
