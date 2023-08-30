using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yfishmove : MonoBehaviour
{
    [SerializeField] private int MoveSpeed;

    [SerializeField]
    private float stopZPosition = 10.0f;
    private int roundedZ;

    private float time;

    private void Awake()
    {
        roundedZ = Mathf.RoundToInt(stopZPosition);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 許容誤差を設定
        float tolerance = 0.1f;

        // Z座標が指定位置の範囲内にあるかどうかをチェック
        if (transform.position.z <= roundedZ - tolerance && transform.position.z <= roundedZ + tolerance)
        {
            Debug.Log("到達");
            // 到達したら何か特定の処理を行う
        }
        else
        {
            transform.Translate(new Vector3(0, 0, MoveSpeed) * Time.deltaTime);
        }
    }




}
