using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBalls : MonoBehaviour
{
    //Getting speed, rigidbody, and original position of Cannonball
    public Vector3 speed;
    private Rigidbody rb;
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        //Getting speed, rigidbody, and original position of Cannonball at the start of the game
        rb = GetComponent<Rigidbody>();
        rb.velocity = speed;
        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Setting velocity of speed
        rb.velocity = speed;

        //Getting cannonball to reset once it moves to its destination
        if (rb.position.x > -50)
        {
            gameObject.transform.position = originalPos;
        }
    }
}
