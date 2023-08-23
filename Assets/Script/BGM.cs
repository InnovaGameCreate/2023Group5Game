using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private AudioLowPassFilter AF;
    [SerializeField] private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        AF = gameObject.GetComponent<AudioLowPassFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y >= 5)AF.enabled = false;
        else AF.enabled = true;
    }
}
