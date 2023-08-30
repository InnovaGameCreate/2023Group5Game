using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeed : MonoBehaviour
{
    [SerializeField] private float accelerationAmount;
    public Transform airstoneTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player‚ÌŒ»İ‚Ìx‚¨‚æ‚ÑzÀ•W‚ğæ“¾
        float playerX = transform.position.x;
        float playerZ = transform.position.z;

        // Airstone‚Ìx‚¨‚æ‚ÑzÀ•W‚ğæ“¾
        float airstoneX = airstoneTransform.position.x;
        float airstoneZ = airstoneTransform.position.z;

        // Player‚ªCube‚Ìx‚¨‚æ‚ÑzÀ•Wã‚ğ’Ê‰ß‚µ‚½ê‡‚É‰Á‘¬‚·‚é
        if (playerX == airstoneX && playerZ == airstoneZ)
        {
            // Player‚ÌRigidbody‚ğæ“¾‚µ‚Ä‰Á‘¬‚·‚é
            Rigidbody playerRigidbody = GetComponent<Rigidbody>();
            playerRigidbody.velocity += Vector3.up * accelerationAmount;
        }
    }
}
