using UnityEngine;
using System.Collections;

public class MenuUI : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void onStartButton ()
	{
		Application.LoadLevel ("MainScene");
	}

	public void onQuitButton ()
	{
		Application.Quit ();
	}

	public void onMenuButton ()
	{
		Application.LoadLevel ("MenuScene");
	}
}
