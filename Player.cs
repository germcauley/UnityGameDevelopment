using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 8f, maxVelocity= 4f;
    
	private Rigidbody2D myBody;
	private Animator animator;

	void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayerMoveKeyboard(){
		float forceX = 0f;
		float vol = Mathf.Abs(myBody.velocity.x);
	}
}
