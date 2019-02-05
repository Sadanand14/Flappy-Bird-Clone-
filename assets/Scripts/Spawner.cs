using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject obstaclePrefab;
	public float frequency = 1f;


	void Start(){
		InvokeRepeating("ChanceForObstacle",0f,1f);
	}

	void ChanceForObstacle(){
		float chance = Random.value;
		if (chance<= 0.2*frequency){
			GenerateObstacle();
		}
	}

	void GenerateObstacle(){
		float height = Random.Range(-0.1f,0.1f);
		Vector2 position = Camera.main.ViewportToWorldPoint( new Vector2 (1.1f,(0.5f+height)));
		GameObject mountain = Instantiate(obstaclePrefab)as GameObject;
		mountain.transform.position = new Vector2 (position.x , height);
		mountain.transform.position = position;
		mountain.transform.SetParent(GameObject.FindObjectOfType<Spawner>().transform);
	}
}
