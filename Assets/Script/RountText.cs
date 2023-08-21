using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RountText : MonoBehaviour
{
    [SerializeField] private Text RoundText;
    private GameObject PM;
    private TestPlayerMove PMCs;

    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("Player");
        PMCs = PM.GetComponent<TestPlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        RoundText.text = "Round " + PMCs.Round.ToString() +" Start!!!";
    }
}
