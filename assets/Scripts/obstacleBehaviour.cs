using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBehaviour : MonoBehaviour {

	public float obstacleVelocity=10f;
	
	void Update () {
		UpdateScale();
		transform.Translate(Vector2.left * obstacleVelocity * Time.deltaTime);
		if(transform.position.x <=-12){
			Destroy (this.gameObject);
		}	
	}

	void UpdateScale(){
		float H = Screen.height;
		float W = Screen.width;
		float aspectRatio= W/H;
		if(aspectRatio >= 1.3){
			transform.localScale = new Vector2(1.0f,(aspectRatio*0.65f)*(3f/4f));
			
		}
		if(aspectRatio<=0.8f && aspectRatio>=0.6f){
			transform.localScale = new Vector2(1.0f,(aspectRatio*0.65f)*(854f/480f));		
		}

		if(aspectRatio <= 0.6f){
			transform.localScale = new Vector2 (1.0f,0.8f);
		}
	}
}
