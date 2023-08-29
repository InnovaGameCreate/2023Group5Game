using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScore : MonoBehaviour
{
    private GameObject SC;
    private ScoreCount SCCs;
    private GameObject PM;
    private TestPlayerMove PMCs;
    [SerializeField] private float boardscore;
    
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
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other. gameObject. CompareTag("Player"))
        {
           if(PMCs.Round == 1){SCCs.firstScore = boardscore;}
        if(PMCs.Round == 2){SCCs.scondScore = boardscore;}
        if(PMCs.Round == 3){SCCs.thirdScore = boardscore;}
        }
    }
}