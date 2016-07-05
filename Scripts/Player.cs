using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public Vector3 direction;
	protected Vector3 targetPosition;
	protected GameManager gmRef;

	public AudioSource grunt;

	private float moveTimer;

	public float moveSpeed;

	// Use this for initialization
	void Start ()
	{
		if (transform.position.y < gmRef.screenBottom) {
			Destroy (this.gameObject);
		}
	}

	// Moves players along the field
	protected void Move ()
	{
		moveTimer += Time.deltaTime * moveSpeed;

		if (moveTimer >= 1.0f) {

			transform.position = new Vector3 (targetPosition.x, targetPosition.y, targetPosition.z);

			// Set target position based on direction and current position
			targetPosition = new Vector3 (transform.position.x + direction.x, 
			                              transform.position.y + direction.y,
			                              transform.position.z + direction.z);


			moveTimer = 0;
		}

		transform.position = Vector3.Lerp (transform.position, targetPosition, moveTimer);

	}

}
