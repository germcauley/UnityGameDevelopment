using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {


	private Vector2 targetPos;
	public float increment;
	public float speed;
	public float maxHeight;
	public float minHeight; 

	public int health = 3;

	public GameObject effect;

	// Update is called once per frame
	void Update () {
		if(health <=0){
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			//SceneManager.LoadScene("GameoverScene");

		}

		transform.position = Vector2.MoveTowards (transform.position, targetPos, speed * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.UpArrow ) &&  transform.position.y < maxHeight) {
			Instantiate (effect, transform.position, Quaternion.identity);
			targetPos = new Vector2(transform.position.x, transform.position.y + increment);

		} else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight) {
			Instantiate (effect, transform.position, Quaternion.identity);
			targetPos = new Vector2(transform.position.x, transform.position.y - increment);


		}
	}
}
