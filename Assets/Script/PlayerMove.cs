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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player���ݒ�̍�����������^��������
        if (!isGravityActive && transform.position.y > targetY)
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

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
