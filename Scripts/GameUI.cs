using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

	public Text scoreText;
	public Text timerText;
	public Text goalsText;

	private GameManager gmRef;

	// Use this for initialization
	void Start ()
	{
		gmRef = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		scoreText.text = "PLAYERS BROKEN: " + GameManager.score;
		timerText.text = "TIME: " + (int)gmRef.gameTimer;
		goalsText.text = "GOALS CONCEDED: " + GameManager.goals;
	}
}
