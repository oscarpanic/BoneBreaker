using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public Defender defender;
	public Attacker attacker;
	public Ball ball;
	public float startX;
	public float startY;
	public static int score;
	public static int goals;
	public int gameLength; 
	public float gameTimer; // Time since the start of the game

	// Variables for Attacker spawning
	public float spawnSpeed; // How often attackers spawn
	public float spawnXmin; // Minimun x position of spawning
	public float spawnXmax; // Maximum x position of spawning
	public float spawnY; // Y position of spawning

	// Screen size limits
	public float screenLeftLimit;
	public float screenRightLimit;
	public float screenBottom;

	public AudioSource crowdLoop;

	private float enemyTimer;

	public static bool ballInPlay = false;


	// Use this for initialization
	void Start ()
	{

		Defender defObj = Instantiate (defender);
		defObj.transform.position = new Vector3 (startX, startY, 0);

		Instantiate (crowdLoop); // Creates sound, which loops

		// Resets score and goals conceded
		score = 0; 
		goals = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameTimer += Time.deltaTime; // Game time progresses

		enemyTimer += Time.deltaTime * spawnSpeed; // Enemies spawn this often

		// Spawn Attackers after a period of time
		if (enemyTimer >= 1.0f) {
			// Instantiate Attacker object
			Attacker attObj = Instantiate (attacker);
			float spawnPos = Random.Range (screenLeftLimit, screenRightLimit); // Randomizes spawn position on specified range
			attObj.transform.position = new Vector3 (spawnPos, spawnY, 0);

			enemyTimer = 0; // Resets timer to spawn attackers

			// If no ball in play, may spawn one.
			if (Random.Range (-1, 1) < 0 && // Randomly decides whether or not to create a ball
				!ballInPlay) { // No ball is in play

				Ball ballObj = Instantiate (ball);

				ballObj.transform.position = new Vector3 (spawnPos, // attacker is in posession of the ball
				                                          spawnY - attObj.GetComponent<BoxCollider> ().size.y * 2, // Ball is a bit under the attacker
				                                          0);
				/*             
				ballObj.transform.position = new Vector3 (attObj.transform.position.x, // attacker is in posession of the ball
				                                          attObj.transform.position.y - attObj.GetComponent<BoxCollider> ().bounds.size.y, // Ball is a bit under the attacker
				                                          attObj.transform.position.z);*/
				ballInPlay = true; // There is now a ball in play
			}
				
		}

		// If time is up, game ends
		if (gameTimer >= gameLength * 1.0f) {
			PlayerPrefs.SetInt ("Score", score);
			PlayerPrefs.SetInt ("Goals", goals);
			Application.LoadLevel ("MatchOverScene");
		}
	}
}
