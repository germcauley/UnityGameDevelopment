using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public int score;

	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Obstacle")){

			score++;
			Debug.Log (score);
		}
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
