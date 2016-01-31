using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum StatusMachine
{

	ESPERANDO,
	START,
	JOGANDO,
	PAUSED,
	GAMEOVER


}

public class GameController : MonoBehaviour {


	private StatusMachine currentStatusMachine;
	private int score;
	public Text textScore;

	//Metodo ja criando Variavel
	public int goldCont{
		get;
		set;
	}

	void Start () 
	{
	
		currentStatusMachine = StatusMachine.ESPERANDO;

	}
	

	void Update () 
	{
		StatusGame ();
	}


	private void StatusGame()
	{
		switch (currentStatusMachine) 
		{
		case StatusMachine.ESPERANDO:
			{
				
			}
			break;
		case StatusMachine.START:
			{
				StartGame ();

			}
			break;
		case StatusMachine.JOGANDO:
			{
				InGame ();
			}
			break;
		case StatusMachine.PAUSED:
			{

			}
			break;
		case StatusMachine.GAMEOVER:
			{
				GameOver ();

			}
			break;

		}

	}

	public StatusMachine SetInGetStatus {
		set{ currentStatusMachine = value; }
		get{ return currentStatusMachine; }
	}

	public int SetInGetScore 
	{
		set{ score = value; }
		get{ return score; }
	}

	private void InGame()
	{
		textScore.text = score.ToString ();

	}

	private void StartGame()
	{
		score = 0;
		currentStatusMachine = StatusMachine.JOGANDO;
	}

	private void GameOver()
	{

		PlayerPrefs.SetInt ("score", score);

		if (score > PlayerPrefs.GetInt ("bestScore")) 
		{
			PlayerPrefs.SetInt ("bestScore", score);
		}

		SceneManager.LoadScene ("GameOver");
	}

	public void MoreScore()
	{
		if (goldCont >= 3) 
		{
			goldCont = 0;
			score += 5;
		}
	}
}
