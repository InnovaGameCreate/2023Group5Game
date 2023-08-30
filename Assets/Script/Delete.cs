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
        // Z座標が指定位置に到達したらスクリプトを無効化
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
                Debug.Log("到達１");
            }
        }
    }

    private void DisableAllScripts()
    {
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
            Debug.Log("到達");
        }
    }
}
