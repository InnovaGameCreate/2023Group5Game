using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScore : MonoBehaviour
{
    private GameObject SC;
    private ScoreCount SCCs;
    [SerializeField] private float boardscore;
    
    // Start is called before the first frame update
    void Start()
    {
        SC = GameObject.Find("ScoreCounter");
        SCCs = SC.GetComponent<ScoreCount>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other. gameObject. CompareTag("Player"))
        {
           SCCs.score = boardscore;
        }
    }
}
