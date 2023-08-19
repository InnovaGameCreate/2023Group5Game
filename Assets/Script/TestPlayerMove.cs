using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float xRange;
    [SerializeField] private float zRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey(KeyCode.D) && this.transform.position.x < xRange)//Dを押したら かつ　オブジェクトのx座標がxRange以下の値なら
        transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime);//移動するためのプログラム
       
       if(Input.GetKey(KeyCode.A) && this.transform.position.x > -xRange)//Aを押したら かつ　オブジェクトのx座標が-xRange以上の値なら
       transform.Translate(new Vector3(-MoveSpeed, 0, 0) * Time.deltaTime);
    
       if(Input.GetKey(KeyCode.W) && this.transform.position.z < zRange)//Wを押したら かつ　オブジェクトのz座標がzRange以下の値なら
       transform.Translate(new Vector3(0, 0, MoveSpeed) * Time.deltaTime);
    
       if(Input.GetKey(KeyCode.S) && this.transform.position.z > -zRange)//Sを押したら かつ　オブジェクトのz座標が-zRange以上の値なら
       transform.Translate(new Vector3(0, 0, -MoveSpeed) * Time.deltaTime);
    }
}
