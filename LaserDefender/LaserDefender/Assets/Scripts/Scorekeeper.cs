using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour {
	public static int PlayerScore = 0;
	private Text myText;


	void Start(){
		myText = GetComponent<Text> ();
		Reset ();
	}


	public void Score(int points){
		PlayerScore += points;
		myText.text = PlayerScore.ToString ();
	}

	public static void Reset(){
		PlayerScore = 0;

	}
		





}
