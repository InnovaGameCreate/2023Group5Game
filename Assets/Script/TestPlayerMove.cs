using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float xRange;
    [SerializeField] private float yRange;

    private Rigidbody rb;
    private bool isStuck = true;
    [SerializeField] private float zSpeed;

    [SerializeField] private GameObject AfterimagePrefab;
    private GameObject Afterimage;
    public float Round;
    [SerializeField] private float waittime;
    [SerializeField] private GameObject RoundText;
    [SerializeField] private GameObject scText;
    [SerializeField] private GameObject fscText;
    public float Fcoefficient;
    public float Scoefficient;
    public float Tcoefficient;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("Test1");
        Round = 1;
        Fcoefficient = 1;
        Scoefficient = 1;
        Tcoefficient = 1;
        scText.SetActive(false);
        fscText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStuck)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {transform.Translate(new Vector3(0, 0, zSpeed) * Time.deltaTime);
        if(Input.GetKey(KeyCode.D) && this.transform.position.x < xRange)//Dを押したら かつ　オブジェクトのx座標がxRange以下の値なら
        transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime);//移動するためのプログラム
       
       if(Input.GetKey(KeyCode.A) && this.transform.position.x > -xRange)//Aを押したら かつ　オブジェクトのx座標が-xRange以上の値なら
       transform.Translate(new Vector3(-MoveSpeed, 0, 0) * Time.deltaTime);
    
       if(Input.GetKey(KeyCode.W) && this.transform.position.y < yRange)//Wを押したら かつ　オブジェクトのz座標がzRange以下の値なら
       transform.Translate(new Vector3(0, MoveSpeed, 0) * Time.deltaTime);
    
       if(Input.GetKey(KeyCode.S) && this.transform.position.y > -yRange)//Sを押したら かつ　オブジェクトのz座標が-zRange以上の値なら
       transform.Translate(new Vector3(0, -MoveSpeed, 0) * Time.deltaTime);
        }

       
    
    
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other. gameObject. CompareTag("Board"))
        {
           isStuck = true;
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
           Round++;
           Debug.Log("Stuck!");
           if(Round <= 3)
           {
            StartCoroutine("Test2");
           }
           else {StartCoroutine("Test3");}
        }
        if(other. gameObject. CompareTag("Double"))
        {
            if(Round == 1){Fcoefficient = 2;}
            if(Round == 2){Scoefficient = 2;}
            if(Round == 3){Tcoefficient = 2;}
        }
        if(other. gameObject. CompareTag("Triple"))
        {
            if(Round == 1){Fcoefficient = 3;}
            if(Round == 2){Scoefficient = 3;}
            if(Round == 3){Tcoefficient = 3;}
        }
    }
    IEnumerator Test1()
    {
        RoundText.SetActive(true);
        yield return new WaitForSeconds(waittime);
        RoundText.SetActive(false);
        isStuck = false;
    }
    IEnumerator Test2()
    {
        scText.SetActive(true);
        yield return new WaitForSeconds(waittime);
        scText.SetActive(false);
        Afterimage = Instantiate(AfterimagePrefab, transform.position, AfterimagePrefab. transform. rotation);
        transform.position = new Vector3(0, 0, 0);
        StartCoroutine("Test1");
    }  
    IEnumerator Test3()
    {
        scText.SetActive(true);
        yield return new WaitForSeconds(waittime);
        scText.SetActive(false);
        fscText.SetActive(true);
    }
}
