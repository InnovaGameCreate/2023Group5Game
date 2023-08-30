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
    {　　// Z座標が指定位置に到達したらオブジェクトの生成を止める
        if (this.transform.position.z > stopZPosition)
        {
            Debug.Log("到達");
        }
        else
        {
            transform.Translate(new Vector3(0, 0, MoveSpeed) * Time.deltaTime);
        }


    }
}
