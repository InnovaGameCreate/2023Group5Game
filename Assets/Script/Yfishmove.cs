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
        // ���e�덷��ݒ�
        float tolerance = 0.1f;

        // Z���W���w��ʒu�͈͓̔��ɂ��邩�ǂ������`�F�b�N
        if (transform.position.z <= roundedZ - tolerance && transform.position.z <= roundedZ + tolerance)
        {
            Debug.Log("���B");
            // ���B�����牽������̏������s��
        }
        else
        {
            transform.Translate(new Vector3(0, 0, MoveSpeed) * Time.deltaTime);
        }
    }




}
