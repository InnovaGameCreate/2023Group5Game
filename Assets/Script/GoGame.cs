using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return)) // �G���^�[�L�[�������ꂽ��
            SceneManager.LoadScene("����"); // �V�[�������[�h
    }
}
