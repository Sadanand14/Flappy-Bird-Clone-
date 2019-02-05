using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashMove : MonoBehaviour {

	private Rigidbody2D body;

	void Start(){
		body = GetComponent<Rigidbody2D>();	
		Begin();
	}

	void Update(){
		UpdateRotation();
		if(transform.position.y<=-20){
			Pounce(); 
		}
	}

	void Begin(){
		if(transform.lossyScale.x>0){
			body.velocity = new Vector2(40f,0f);
		}
		else{
			body.velocity = new Vector2(-40f,0f);
		}
	}


	void Pounce(){
		if(transform.lossyScale.x>0){
			body.velocity = new Vector2 (40f, 70f);
		} 
		else{
			body.velocity = new Vector2 (-40f, 70f);
		}
	}


	void UpdateRotation(){
		float angle = Mathf.Rad2Deg * Mathf.Atan(body.velocity.y / body.velocity.x);
		transform.rotation = Quaternion.Euler (0, 0, angle);
	}
}
