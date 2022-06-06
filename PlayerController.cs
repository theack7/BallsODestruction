using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	// Create public variables for player speed
	public float speed = 0;

    //variables for player's rigidbody, original position and directions it moves
    private Rigidbody rb;
	private Vector3 originalPos;
	private float movementX;
	private float movementY;

    // At the start of the game..
    void Start()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		//How to keep the original position of the player
        originalPos = gameObject.transform.position;
    }

	private void OnMove(InputValue movementValue)
	{
		//How to get the movement value
		Vector2 movementVector = movementValue.Get<Vector2>();

		//How to represent the movement value through the x and y variables stated above
		movementX = movementVector.x;
		movementY = movementVector.y;
	}

	private void FixedUpdate()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

		//How to get the speed
		rb.AddForce(movement * speed);

		//How to add speed to player's rigidbody
		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);

		//How to respawn player if player goes below a certain y value
        if (rb.position.y < -3)
        {
            gameObject.transform.position = originalPos;
        }
	}
}