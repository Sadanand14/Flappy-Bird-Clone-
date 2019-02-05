using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCondition : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D obj){
		if(obj.gameObject.GetComponent<PlaneController>()){
			//Reset the game	
		}
	}
}
