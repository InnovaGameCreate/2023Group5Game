using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    private GameObject MainCamera;
    private GameObject SubCamera;
    private GameObject PM;
    private TestPlayerMove PMCs;

    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("Player");
        PMCs = PM.GetComponent<TestPlayerMove>();
        
        MainCamera = GameObject.Find("Main Camera");
        SubCamera = GameObject.Find("SubCamera");

        SubCamera.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PMCs.Round > 3)
        {
            MainCamera.SetActive(false);
            SubCamera.SetActive(true);
        }
    }
    
}
