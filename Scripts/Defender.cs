using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Defender : Player
{

	protected Slider boostSlider;
	protected float baseSpeed; // Base speed is saved in order to reset original speed after boosting
	protected float boostingTimer; // Timer for boosting

	public int boostDepletion; // Helps determine how long it boost may be used
	public int boostStrength; // How strong the defender's boost is

	// Use this for initialization
	void Start ()
	{
		// Game begins, defender slides towards one side

		targetPosition = new Vector3 (transform.position.x, 
		                              transform.position.y,
		                              transform.position.z); // Not moving at first

		gmRef = FindObjectOfType<GameManager> ();

		boostSlider = FindObjectOfType<Slider> ();

		boostingTimer = 0; // Resets boosting timer
		baseSpeed = moveSpeed; // Stores base move speed for resetting
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		boostingTimer += Time.deltaTime;  // Timer for boosting


		// Defender switches direction with spacebar
		if (Input.GetKeyDown (KeyCode.Space)) {
			// Key pressed, direction is changed
			changeDirection ();
			boostingTimer = 0;

		} else if (Input.GetKey (KeyCode.W) && // W is pressed
			boostSlider.value > boostSlider.minValue && // Boost slider is not empty
			boostingTimer >= 1.0f / boostDepletion) { // Checks boost timer

			// Key hold and Defender is boosted
			boostSlider.GetComponent<BoostSlider> ().boosting = true; //  Tells slider that player is boosting
			boostSlider.value--;
			moveSpeed *= boostStrength;
			boostingTimer = 0; // Resets boostingTimer

		} else if (Input.GetKeyUp (KeyCode.W) || // W is released
			boostSlider.value <= boostSlider.minValue) { // Boost bar depleted

			// Key released and boost ends
			boostSlider.GetComponent<BoostSlider> ().boosting = false; //  Tells slider that player is boosting
			moveSpeed = baseSpeed; // Speed is reset
		}

		// If reached end of game area, changes direction
		if (((transform.position.x > gmRef.screenRightLimit) && direction.x > 0) ||
			((transform.position.x < gmRef.screenLeftLimit) && direction.x < 0)) { // Also checks direction to avoid getting stuck by changing direction twice
			changeDirection ();
		}

		// Moves
		Move ();

	}

	// Collides
	void OnTriggerEnter (Collider coll)
	{

		// Collides with an attacker
		if (coll.tag == "Attacker") {
			// Score increases and attacker is destroyed
			GameManager.score++;
			AudioSource g = Instantiate (grunt);
			g.Play ();

			Destroy (coll.gameObject); // DIE, DEFENDER
		}

	}

	// Changes direction of movement
	public void changeDirection ()
	{
		direction = new Vector3 (-1 * direction.x, direction.y, direction.z); // Opposite direction
		transform.localScale = new Vector3 (-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z); // Flips sprite
	}
	
}
