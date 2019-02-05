using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Levelmanager : MonoBehaviour {
	
	public float LoadNextLevelAfter; 
	
	void Start(){
		if(LoadNextLevelAfter!=0){
			Invoke("loadNextLevel", LoadNextLevelAfter);
		} 
	}

	public void LoadLevel(string name){
		SceneManager.LoadScene(name);
	}
	
	public void QuitGame(){
		Debug.LogWarning("Quit game");
		Application.Quit();
	}

	public void loadNextLevel(){
	DontDestroyOnLoad(GameObject.FindObjectOfType<Levelmanager>());
	SceneManager.LoadScene(sceneBuildIndex:+1);
	}
}	
