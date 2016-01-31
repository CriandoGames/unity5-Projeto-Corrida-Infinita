using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour 
{
	public AudioClip audiobt;
	public AudioSource audio;
	public void ChangeScene()
	{
		audio.PlayOneShot (audiobt, 8);
		SceneManager.LoadScene ("GamePlay");
	}

}
