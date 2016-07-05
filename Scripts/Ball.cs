using UnityEngine;
using System.Collections;

public class Ball : Player
{

	// Use this for initialization
	void Start ()
	{
		targetPosition = new Vector3 (transform.position.x, 
		                              transform.position.y,
		                              transform.position.z); // Not moving at first

		gmRef = FindObjectOfType<GameManager> (); // Reference to GameManager
	}

	// Update is called once per frame
	void Update ()
	{
		if (transform.position.y < gmRef.screenBottom) {
			// Ball gets past the defender
			GameManager.goals++; // Loses score
			GameManager.ballInPlay = false; // Ball is out of play
			Destroy (this.gameObject); // Byebye ball

		} else if ((transform.position.x > gmRef.screenRightLimit ||
			transform.position.x < gmRef.screenLeftLimit)) {
			// Ball is successfully cleared
			GameManager.ballInPlay = false; // Ball is out of play
			Destroy (this.gameObject); // Auf wiedersehen, Ball

		}

		Move ();
	}

	// Collides
	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Attacker") {
			// Attacker is in possession of the ball
			direction = col.GetComponent<Attacker> ().direction;
			moveSpeed = col.GetComponent<Attacker> ().moveSpeed;
			//transform.SetParent (col.gameObject.transform, true);

			// Sound
			gameObject.GetComponent<AudioSource> ().Play ();

		} else if (col.tag == "Defender") {
			// Defender clears the ball
			direction = col.GetComponent<Defender> ().direction;
			moveSpeed += col.GetComponent<Defender> ().moveSpeed;

			// Sound
			gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
}
