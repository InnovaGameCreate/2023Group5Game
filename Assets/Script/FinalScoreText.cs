using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreText : MonoBehaviour
{
    [SerializeField] private Text fscText;
    private GameObject SC;
    private ScoreCount SCCs;
    
    // Start is called before the first frame update
    void Start()
    {
        SC = GameObject.Find("ScoreCounter");
        SCCs = SC.GetComponent<ScoreCount>();
    }

    // Update is called once per frame
    void Update()
    {
        fscText.text = SCCs.finalScore.ToString() +"Points!!!";
    }
}
