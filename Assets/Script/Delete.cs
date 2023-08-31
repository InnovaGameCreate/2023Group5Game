using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    [SerializeField]
    private float targetY = 0.0f; // You need to define targetY
    [SerializeField]
    private float targetZ = 0.0f; // You need to define targetZ
    private bool isGravityActive = false; // You need to define isGravityActive

    private bool shouldDisable = false;
    private float elapsedTime = 0.0f;

    private void Update()
    {
        if ((!isGravityActive && transform.position.y > targetY) || (!isGravityActive && transform.position.z > targetZ))
        {
            Debug.Log("…‘…‚©‚ço‚Ü‚µ‚½");
            shouldDisable = true;
        }

        if (shouldDisable)
        {
            elapsedTime += Time.deltaTime;

        }
    }

    private void DisableAllScripts()
    {
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
            Debug.Log("“’B");
        }
    }
}
