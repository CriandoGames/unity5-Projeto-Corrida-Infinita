using UnityEngine;
using System.Collections;

public class SpwanGold : MonoBehaviour {

	public GameObject  prefabGold;
	public Transform point;
	public float forceX;

	public float timeToSpwan;

	private GameController gamecontroller;
	private float currentTime;
	void Start () 
	{
		
		gamecontroller = FindObjectOfType (typeof(GameController)) as GameController;
	}


  
	void FixedUpdate () 
	{
		if (gamecontroller.SetInGetStatus == StatusMachine.JOGANDO) 
		{
			currentTime += Time.deltaTime;
		}
		if (currentTime >= timeToSpwan) 
		{
			Spwan ();
			currentTime = 0;
		}
	}


	public void Spwan ()
	{
		GameObject tempPrefab = Instantiate (prefabGold) as GameObject;
		tempPrefab.transform.position = point.transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2(forceX, 0));
	}
}
