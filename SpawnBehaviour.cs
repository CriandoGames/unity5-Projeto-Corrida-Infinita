using UnityEngine;
using System.Collections;

public class SpawnBehaviour : MonoBehaviour {

	private float currentTimeToSpawn;
	private GameController gamecontroller;
	[Header("Tempo maximo para instanciar")][Space(5)]
	public float timeToSpawn;
	[Header("objetos a serem instanciados")][Space(5)]
	public GameObject[] prefabsObstaculos;

	void Start () 
	{
		gamecontroller = FindObjectOfType (typeof(GameController)) as GameController;
		currentTimeToSpawn = timeToSpawn;
	}
	

	void Update () 
	{
		if (gamecontroller.SetInGetStatus == StatusMachine.JOGANDO) 
		{
			currentTimeToSpawn += Time.deltaTime;
			if (currentTimeToSpawn >= timeToSpawn) 
			{
				Spwan ();
				currentTimeToSpawn = 0;
			}
		}

	}

	private void Spwan()
	{
		int i = Random.Range (0, prefabsObstaculos.Length);

		Instantiate (prefabsObstaculos [i], transform.position, Quaternion.identity);

	}
}
