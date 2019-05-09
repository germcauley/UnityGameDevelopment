using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text myText = GetComponent<Text> ();
		myText.text = Scorekeeper.PlayerScore.ToString ();
		Scorekeeper.Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
