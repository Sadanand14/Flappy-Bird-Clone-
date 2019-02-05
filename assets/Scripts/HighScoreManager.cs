using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

	const string SAVED_HIGHSCORE_KEY = "save_score";
	private Text Best;
	private static int HighScore=0; 
	
	void Start () {
		HighScore = GetSavedScore();
		Best = GetComponent<Text>();
	}

	void Update () {
		Best.text = HighScore.ToString();

	}

	public void UpdateHighScore(int score){
		if(score > HighScore){
			HighScore = score;
			SaveHighscore(score);
		}
	}

	private static void SaveHighscore(int score){
		PlayerPrefs.SetInt (SAVED_HIGHSCORE_KEY,score);
	}

	private static int GetSavedScore(){
		return PlayerPrefs.GetInt(SAVED_HIGHSCORE_KEY);
	}
}
