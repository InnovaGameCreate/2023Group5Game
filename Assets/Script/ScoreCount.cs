using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public float firstScore;
    public float scondScore;
    public float thirdScore;
    public float finalScore;

    // Start is called before the first frame update
    void Start()
    {
        firstScore = 0;
        scondScore = 0;
        thirdScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        finalScore = firstScore + scondScore + thirdScore;
        
    }
}
