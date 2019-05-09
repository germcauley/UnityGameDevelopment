using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    //movement speed
    [SerializeField]
    public float speed = 15.0f;
    public float padding = 1f;
    public GameObject projectile;
    public float projectileSpeed =10;
	[SerializeField]
    public float firingRate = 0.2f;
	public float health = 250f;

	public AudioClip fireSound;
	[SerializeField]
	public float laserVolume = 0.1f;

    float xmin =-5;
    float xmax = 5;

    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;



    }

    //Fire rate
    void Fire()
    {
		Vector3 offset = new Vector3 (0, 1, 0);
        GameObject beam = Instantiate(projectile, transform.position + offset, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
		AudioSource.PlayClipAtPoint (fireSound, transform.position,laserVolume);
	}




    // Update is called once per frame
    void Update () {
        //Shoot laser
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
			
            //Movement
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                //same thing
                transform.position += Vector3.left * speed * Time.deltaTime;

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        //restrict player to the gamespace
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

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
		LevelManager man =GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		man.LoadLevel ("Win Screen");
		Destroy(gameObject);
	}


}
