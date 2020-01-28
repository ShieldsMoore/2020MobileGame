﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public string mainMenu;
	private LevelManager theLevelManager;

	// Use this for initialization
	void Start () {
		theLevelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Restart()
	{
		PlayerPrefs.SetInt ("CoinCount", 0);
		//PlayerPrefs.SetInt ("PlayerLives", theLevelManager.startingLives);

		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void QuitToMainMenu()
	{
		SceneManager.LoadScene (mainMenu);
	}


}
