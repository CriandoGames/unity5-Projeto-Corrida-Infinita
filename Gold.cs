using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Gold : MonoBehaviour {
	private GameController gamecontroller;

	void Start()
	{
		gamecontroller = FindObjectOfType (typeof(GameController)) as GameController;
	}

	public void AddGoldCont()
	{
		gamecontroller.goldCont += 1;
	}
}
