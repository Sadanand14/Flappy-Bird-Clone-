using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	private Text ScoreText;
	private int score = 0;
	private HighScoreManager highscoremanager;

	void Start () {
		ScoreText = GetComponent<Text>();
		highscoremanager = GameObject.FindObjectOfType<HighScoreManager>();
	}
	
	void Update () {
		ScoreText.text = score.ToString();
		highscoremanager.UpdateHighScore(score);
	}

	public void Increment(){
		score+=1;
	}

	public void ResetScore(){
		score= 0;
	}
}
