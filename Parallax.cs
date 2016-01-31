using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public Material material;
	public float speed;

	private float offset;
	private GameController gamecontroller;
	void Start () 
	{
		material = GetComponent<Renderer> ().material;
		gamecontroller = FindObjectOfType (typeof(GameController)) as GameController;
	}
	

	void Update () 
	{
		if (gamecontroller.SetInGetStatus == StatusMachine.JOGANDO) {
			offset += speed * Time.deltaTime;

			material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
		}
	
	}
}
