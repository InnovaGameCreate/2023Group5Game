using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private Text scText;
    private GameObject SC;
    private ScoreCount SCCs;
    private GameObject PM;
    private TestPlayerMove PMCs;
    
    // Start is called before the first frame update
    void Start()
    {
        SC = GameObject.Find("ScoreCounter");
        SCCs = SC.GetComponent<ScoreCount>();
        PM = GameObject.Find("Player");
        PMCs = PM.GetComponent<TestPlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(PMCs.Round == 1){scText.text = SCCs.firstScore.ToString() +"Points!";}
        if(PMCs.Round == 2){scText.text = SCCs.scondScore.ToString() +"Points!";}
        if(PMCs.Round == 3){scText.text = SCCs.thirdScore.ToString() +"Points!";}
    }
}