using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBalls : MonoBehaviour
{
    //Get rigidbody and original position of the bouncing balls
    private Rigidbody rb;
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        //Get rigidbody and original position of the bouncing balls at the start of the game
        rb = GetComponent<Rigidbody>();
        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //How to reset balls once they get to their destination 
        if(rb.position.y < 2.1)
        {
            gameObject.transform.position = originalPos;
        }
    }
}
