using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorConroller : MonoBehaviour {

	public Sprite[] indicatorSprite;
	private int index=0;

	void Start() {
		InvokeRepeating("SwitchSprite",0.7f,0.7f);
	}

	void SwitchSprite(){
		if (index==0){
			index = 1;				
		}
		else{
			index=0;
		}
		GetComponent<SpriteRenderer>().sprite = indicatorSprite[index]; 
	}

}
