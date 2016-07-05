using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MatchOver : MonoBehaviour
{

	private int highScore;
	private int score;
	private int goals;
	private int totalScore;

	public Text scoreText;
	public Text highscoreText;
	public Text goalsText;
	public Text totalScoreText;

	public int goalPenalty;

	// Use this for initialization
	void Start ()
	{
		// Loads score and high score
		score = PlayerPrefs.GetInt ("Score", 0);
		highScore = PlayerPrefs.GetInt ("HighScore", 0);
		goals = PlayerPrefs.GetInt ("Goals", 0);
		totalScore = score - goals * goalPenalty;

		// If score beats high score, it replaces it
		if (totalScore > highScore) {
			highScore = totalScore;
			PlayerPrefs.SetInt ("HighScore", highScore);
		}

		// Displayes scores
		scoreText.text = "BONES BROKEN: " + score;
		goalsText.text = "GOALS CONCEDED: " + goals;
		totalScoreText.text = "TOTAL SCORE: " + totalScore;
		highscoreText.text = "HIGH SCORE: " + highScore;


	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
