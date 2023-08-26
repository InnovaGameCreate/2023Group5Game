using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public float firstScore;
    public float scondScore;
    public float thirdScore;
    public float finalScore;
    public float score;
    private GameObject PM;
    private TestPlayerMove PMCs;

    // Start is called before the first frame update
    void Start()
    {
        firstScore = 0;
        scondScore = 0;
        thirdScore = 0;
        finalScore = firstScore + scondScore + thirdScore;
        PM = GameObject.Find("Player");
        PMCs = PM.GetComponent<TestPlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PMCs.Round == 2){score = firstScore;}
        if(PMCs.Round == 3){score = scondScore;}
        if(PMCs.Round == 4){score = thirdScore;}
    }
}
