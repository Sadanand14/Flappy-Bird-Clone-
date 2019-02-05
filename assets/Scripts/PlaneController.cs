using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {
	
	public Sprite[] planeSprite; 
	public float pounceVelocity = 20f;
	private int spriteIndex=0;
	private Rigidbody2D body;
	private GameKeeper gamekeeper;
	private ScoreKeeper scorekeeper;
	private float screenRatio;


	void Start(){

		gamekeeper = GameObject.FindObjectOfType<GameKeeper>();
		body = GetComponent<Rigidbody2D>();
		body.bodyType = RigidbodyType2D.Static;
		scorekeeper = GameObject.FindObjectOfType<ScoreKeeper>();
	}
	void Update(){
		UpdateRotation();
		UpdateScale();
	}

	void UpdateScale(){
		float H = Screen.height;
		float W = Screen.width;
		float aspectRatio= W/H;
		screenRatio = aspectRatio;
		if(aspectRatio >= 1.3){
			
			transform.localScale = new Vector2 (aspectRatio*(5f/8f), aspectRatio*(5f/8f));
		}
		if(aspectRatio<=0.8f){
			transform.localScale = new Vector2((aspectRatio*0.7f)*(854f/480f),(aspectRatio*0.7f)*(854f/480f));		
		}
	}

	public void ChangeSprite(){
		if (spriteIndex == 0){
			spriteIndex = 1;
		}
		else{
			spriteIndex = 0;	
		}

		this.GetComponent<SpriteRenderer>().sprite = planeSprite[spriteIndex];
	}	

	public void UseGravity(){
		body.bodyType = RigidbodyType2D.Dynamic;
	}

	public void Reset(){
		transform.position = new Vector2 (0f,0f);
		body.velocity = Vector2.zero;
	}

	public void ResetToMenu(){
		transform.position = new Vector2 (0f,0f);
		body.bodyType = RigidbodyType2D.Static;
	}


	public void Pounce(){
		if( screenRatio>= 1.3f){
			body.velocity = new Vector2 (0f, pounceVelocity);	 
		}
		if(screenRatio<=0.8){
			body.velocity = new Vector2 (0f, pounceVelocity);	 
		}
	}


	void UpdateRotation(){
		float angle = Mathf.Rad2Deg * Mathf.Atan(body.velocity.y / 10f);
		transform.rotation = Quaternion.Euler (0, 0, angle);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.GetComponent<obstacleBehaviour>()){
			scorekeeper.Increment();
		}
		else{
			gamekeeper.GameReset();
			scorekeeper.ResetScore();
		}
	}
}
