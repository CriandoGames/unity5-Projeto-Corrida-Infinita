﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{

	public Text bestScore;
	public Text score;

	void Start () 
	{
		bestScore.text = PlayerPrefs.GetInt ("bestScore").ToString();
		score.text = PlayerPrefs.GetInt ("score").ToString();
	}
	
	public void ChangeScene(string cena)
	{
		SceneManager.LoadScene (cena);
	}

}
