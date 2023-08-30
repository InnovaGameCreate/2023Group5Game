using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlayerMove : MonoBehaviour
{
  
            [SerializeField] private float MoveSpeed;
            [SerializeField] private float xMax;
            [SerializeField] private float xMin;
            [SerializeField] private float yMax;
            [SerializeField] private float yMin;
            //private このスクリプト内でしか書き換えられない
            //public どこからでも書き換えられる
            //[SerializeFIeld] private unity上では変えられるけど他のスクリプトでは変えられない
            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {
                if (Input.GetKey(KeyCode.A) && this.transform.position.x > xMin)//Aを押したら移動、かつオブジェクトのx座標がxMin以上の値なら移動可能
                    transform.Translate(new Vector3(-MoveSpeed, 0, 0) * Time.deltaTime); //移動するためのプログラム

                if (Input.GetKey(KeyCode.D) && this.transform.position.x < xMax)//Dを押したら移動、かつオブジェクトのx座標がxMax以下の値なら移動可能
                    transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime); //移動するためのプログラム

                if (Input.GetKey(KeyCode.W) && this.transform.position.y < yMax)//Wを押したら移動、かつオブジェクトのz座標がzMax以下の値なら移動可能
                    transform.Translate(new Vector3(0, MoveSpeed, 0) * Time.deltaTime); //移動するためのプログラム

                if (Input.GetKey(KeyCode.S) && this.transform.position.y > yMin)//Sを押したら移動、かつオブジェクトのz座標がxMin以上の値なら移動可能
                    transform.Translate(new Vector3(0, -MoveSpeed, 0) * Time.deltaTime); //移動するためのプログラム

         

             }

  
}
