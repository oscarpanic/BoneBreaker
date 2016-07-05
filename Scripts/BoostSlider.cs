using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoostSlider : MonoBehaviour
{

	private Slider boostSlider; // Will contain Slider component of GameObject
	private float refillTimer;

	public int refillSpeed;
	public bool boosting;
	// Use this for initialization
	void Start ()
	{
		boostSlider = gameObject.GetComponent<Slider> (); // Slider component
		refillTimer = 0; // Sets refill timer to 0
	}
	
	// Update is called once per frame
	void Update ()
	{

		refillTimer += Time.deltaTime; // Time elapses

		// Refills timer as time progresses
		if (boostSlider.value < boostSlider.maxValue && // Slider is not full
			!boosting && // Player is not boosting at the moment
			refillTimer > 1.0f * refillSpeed) { // Enough time has passed for slider to refill
			boostSlider.value++;
			refillTimer = 0;
		}

	}
}
