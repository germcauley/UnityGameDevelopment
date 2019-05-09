using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybehaviour : MonoBehaviour {
	
	public GameObject projectile;
	public float projectileSpeed = 10;
    public float health = 150;
	public float shotsPerSeconds = 0.5f;
	public int scoreValue =150;
	public AudioClip fireSound;
	public AudioClip deathSound;

	private Scorekeeper scoreKeeper;

	void Start(){
		scoreKeeper = GameObject.Find ("Score").GetComponent<Scorekeeper> ();
	}

	void Update(){
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability) {
			Fire ();
		}

	}

	void Fire(){
		Vector3 startPosition = transform.position + new Vector3 (0, -1, 0);
		GameObject missle = Instantiate (projectile, startPosition, Quaternion.identity);
		missle.GetComponent<Rigidbody2D>().velocity= new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint (fireSound, transform.position);
	}


    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider);
        Projectile missle = collider.gameObject.GetComponent<Projectile>();
        if (missle)
        {
            health -= missle.GetDamage();
            missle.Hit();
            if(health <= 0)
            {
				Die ();

            }
            //Debug.Log("Hit by a projectile!");
        }
    }

	void Die(){
		AudioSource.PlayClipAtPoint (deathSound, transform.position);
		Destroy(gameObject);
		scoreKeeper.Score (scoreValue);
	}


}
