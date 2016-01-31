using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {


	//public
	public AudioClip audioJump;
	public AudioClip audioGold;
	public AudioSource audio;
	[Header("Selecione a Layer do Chão")][Space(5)]
	public LayerMask qualLayer;
	[Header("Atributo para adicionar força ao Pulo")]
	public int forceJump;
	//private
	private Animator anim; // controlar nossa animação
	private bool start;
	private GameController gamecontroller;
	private Rigidbody2D rgd2Player;
	private Transform check;
	private bool isGround;

	void Start () 
	{
		gamecontroller = FindObjectOfType (typeof(GameController)) as GameController;
		anim = GetComponentInChildren<Animator> ();
		rgd2Player = GetComponent<Rigidbody2D> ();
		check = GameObject.Find ("Check").gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Moviment ();
	}

	private void Moviment()
	{
		if (Input.anyKey && !start ) 
		{
			gamecontroller.SetInGetStatus = StatusMachine.START;
			anim.SetBool ("run", true);
			start = true;
		
		}

		if (Input.GetKeyDown (KeyCode.Space) && start && isGround) 
		{
			audio.PlayOneShot (audioJump, 0.5f);
			rgd2Player.AddForce(new Vector2(0,forceJump));


		}

		isGround = Physics2D.OverlapCircle (check.position, 0.02f, qualLayer);

		if (start == true) 
		{
			anim.SetBool ("run", isGround);
			anim.SetBool ("jump", !isGround);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "obstaculos") 
		{
			
			gamecontroller.SetInGetStatus = StatusMachine.GAMEOVER;
		}

	}


	void OnTriggerEnter2D(Collider2D other)
	{
		switch (other.gameObject.tag) 
		{
		case "Gold":
			other.GetComponent<Gold> ().AddGoldCont ();
			gamecontroller.MoreScore ();
			Destroy (other.gameObject);

			break;

		}
	}


}
