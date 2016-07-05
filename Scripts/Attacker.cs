using UnityEngine;
using System.Collections;

public class Attacker : Player
{
	

	// Use this for initialization
	void Start ()
	{
		targetPosition = new Vector3 (transform.position.x, 
		                              transform.position.y,
		                              transform.position.z); // Does not move at the beginning of its existence

		gmRef = FindObjectOfType<GameManager> (); // Reference to GameManager
		moveSpeed += Random.Range (moveSpeed, (gmRef.gameTimer * 1.0f) / 3); // Sets a speed range. Maximum possible speed increases with time

	}
	
	// Update is called once per frame
	void Update ()
	{
		// If attackers leave screen through the bottom, they are destroyed
		if (transform.position.y < gmRef.screenBottom) {
			Destroy (this.gameObject);
		}

		Move ();
	}


}
