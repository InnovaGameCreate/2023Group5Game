using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    [SerializeField]
    private float stopZPosition = 10.0f;

    private bool shouldDisable = false;
    private float elapsedTime = 0.0f;

    private void Update()
    {
        // Z���W���w��ʒu�ɓ��B������X�N���v�g�𖳌���
        if (!shouldDisable && transform.position.z >= stopZPosition)
        {
            shouldDisable = true;
        }

        if (shouldDisable)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= 5.0f)
            {
                DisableAllScripts();
                Debug.Log("���B�P");
            }
        }
    }

    private void DisableAllScripts()
    {
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
            Debug.Log("���B");
        }
    }
}
