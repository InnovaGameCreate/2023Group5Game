using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private int boardCollisionCount = 0;

    private const int MaxBoardCollisions = 3;

    public void LoadEndScene()
    {
        SceneManager.LoadScene("End");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Board")
        {
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
}
