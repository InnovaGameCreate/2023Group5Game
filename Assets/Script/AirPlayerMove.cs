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
            //private ���̃X�N���v�g���ł��������������Ȃ�
            //public �ǂ�����ł�������������
            //[SerializeFIeld] private unity��ł͕ς����邯�Ǒ��̃X�N���v�g�ł͕ς����Ȃ�
            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {
                if (Input.GetKey(KeyCode.A) && this.transform.position.x > xMin)//A����������ړ��A���I�u�W�F�N�g��x���W��xMin�ȏ�̒l�Ȃ�ړ��\
                    transform.Translate(new Vector3(-MoveSpeed, 0, 0) * Time.deltaTime); //�ړ����邽�߂̃v���O����

                if (Input.GetKey(KeyCode.D) && this.transform.position.x < xMax)//D����������ړ��A���I�u�W�F�N�g��x���W��xMax�ȉ��̒l�Ȃ�ړ��\
                    transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime); //�ړ����邽�߂̃v���O����

                if (Input.GetKey(KeyCode.W) && this.transform.position.y < yMax)//W����������ړ��A���I�u�W�F�N�g��z���W��zMax�ȉ��̒l�Ȃ�ړ��\
                    transform.Translate(new Vector3(0, MoveSpeed, 0) * Time.deltaTime); //�ړ����邽�߂̃v���O����

                if (Input.GetKey(KeyCode.S) && this.transform.position.y > yMin)//S����������ړ��A���I�u�W�F�N�g��z���W��xMin�ȏ�̒l�Ȃ�ړ��\
                    transform.Translate(new Vector3(0, -MoveSpeed, 0) * Time.deltaTime); //�ړ����邽�߂̃v���O����

         

             }

  
}
