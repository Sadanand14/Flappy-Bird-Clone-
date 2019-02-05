using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKeeper : MonoBehaviour {

	public GameObject PlanePrefab,SpawnerPrefab;

	private GameObject title,touch1,touch2,instruction,planebutton,indicator,scoreKeeper,spawner,menuButton,quitButton;
	private PlaneController controller;

	void Start() {
		controller = GameObject.FindObjectOfType<PlaneController>();
		ControlOrder();
		MainMenu();
	}

	void ControlOrder(){
		scoreKeeper = GameObject.Find("Canvas").transform.Find("ScoreBox").gameObject;
		title = GameObject.Find("Canvas").transform.Find("Title").gameObject;
		touch1 = GameObject.Find("Canvas").transform.Find("Touch Input").gameObject;
		touch2= GameObject.Find("Canvas").transform.Find("Ingame Input").gameObject;
		menuButton = GameObject.Find("Canvas").transform.Find("Menu Button").gameObject;
		planebutton = GameObject.Find("Canvas").transform.Find("Plane Swtich Button").gameObject;
		instruction = GameObject.Find("Canvas").transform.Find("Instruction").gameObject;
		quitButton = GameObject.Find("Canvas").transform.Find("Quit Button ").gameObject;
		indicator = GameObject.Find("Indicator"); 
	}

	public void GameStart(){
		scoreKeeper.SetActive(true);
		touch2.SetActive(true);
		menuButton.SetActive(true);
		spawner.SetActive(true);
		touch1.SetActive(false);
		title.SetActive(false);
		planebutton.SetActive(false);
		instruction.SetActive(false);
		indicator.SetActive(false);
		quitButton.SetActive(false);
		controller.UseGravity();
	}

	public void GameReset(){
		controller.Reset();
		DestroyObject(spawner);
		spawner = Instantiate(SpawnerPrefab);
		spawner.transform.position = Vector3.zero;
		spawner.SetActive(true);
	}

	public void MainMenu(){
		DestroyObject(spawner);
		spawner = Instantiate(SpawnerPrefab);
		spawner.transform.position = Vector3.zero;
		scoreKeeper.SetActive(false);
		touch2.SetActive(false);
		menuButton.SetActive(false);
		spawner.SetActive(false);
		touch1.SetActive(true);
		title.SetActive(true);
		planebutton.SetActive(true);
		instruction.SetActive(true);
		indicator.SetActive(true);
		quitButton.SetActive(true);
		controller.ResetToMenu();

	}
}
