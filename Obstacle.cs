using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private GameController gamecontroller;
	private PlayerBehaviour player;
	private bool passed;
	//public
	[Header("Atributo velocidade Obstaculo")]
	public float speed;
	void Start () 
	{
		gamecontroller = FindObjectOfType (typeof(GameController)) as GameController;
		player = FindObjectOfType (typeof(PlayerBehaviour)) as PlayerBehaviour;
	}
	

	void Update () 
	{
		if (gamecontroller.SetInGetStatus == StatusMachine.JOGANDO) 
		{
			transform.Translate (-speed*Time.deltaTime, 0, 0);
			CheckPosition ();
		}
	
	}

	private void CheckPosition()
	{
		if (player.gameObject.transform.position.x > transform.position.x && !passed) 
		{
			player.audio.PlayOneShot (player.audioGold,0.5f);
			passed = true;
			gamecontroller.SetInGetScore += 1;
		}

		if (transform.position.x <= -4.5f) 
		{
			Destroy (gameObject);
		}
	}




}
