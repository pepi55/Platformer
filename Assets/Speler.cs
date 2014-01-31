using UnityEngine;
using System.Collections;

public class Speler : MonoBehaviour {
	bool isOnPlatform = true;
	float time;
	float enemytime;
	Vector3 spawnE = new Vector3(14, 3, 0);
	
	void FixedUpdate () {
		Vector3 snelheid = new Vector3();
		time += Time.deltaTime;
		enemytime += Time.deltaTime;
		snelheid.y = rigidbody.velocity.y;
		
		if (enemytime > 1)
		{
			Instantiate (Resources.Load("Vijand2"), spawnE, Quaternion.identity);
			enemytime = 0;
		}
		
		if (Input.GetAxis ("Fire1") > 0 && time > 0.5f)
		{
			Vector3 vector3 = transform.position;
			if (Globaal.direction)
			{
				vector3.x = gameObject.transform.position.x + 1.1f;
			}
			
			if (Globaal.direction == false)
			{
				vector3.x = gameObject.transform.position.x - 1.1f;
			}
			
			Instantiate (Resources.Load("Bullet"), vector3, Quaternion.identity);
			time = 0;
		}
		
		if (Input.GetAxis("Horizontal") < 0)
		{
			snelheid.x = -10;
			Globaal.direction = false;
		}
		else if (Input.GetAxis("Horizontal") > 0)
		{
			snelheid.x = 10;
			Globaal.direction = true;
		}
		else
		{
			snelheid.x = 0;
		}
		
		if (Input.GetAxis("Jump") > 0 && isOnPlatform)
		{
			snelheid.y = 15;
			//rigidbody.AddForce(new Vector3(0, 500, 0));
			isOnPlatform = false;
		}
		
		rigidbody.velocity = snelheid;
		
		if (transform.position.y < -5)
		{
			Globaal.getal = 0;
			Application.LoadLevel(0);	
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.collider.name == "Coin")
		{
			Globaal.getal += 5;
			Destroy(col.collider.gameObject);
		}
		
		if (col.collider.name == "Win")
		{
			//Debug.Log(Globaal.won);
			Globaal.won = true;
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.contacts[0].normal.y > 0.7f)
		{
			isOnPlatform = true;
		}
		
		if (col.collider.name == "Vijand" && col.contacts[0].normal.y > 0.7f)
		{
			Globaal.getal += 10;
			Destroy(col.collider.gameObject);
		}
		
		if (col.collider.name == "Vijand2(Clone)" || col.collider.name == "Vijand")
		{
			Globaal.getal = 0;
			Application.LoadLevel(0);	
		}
		
		if (col.collider.name == "Springveer")
		{
			//snelheid.y = 15;
			rigidbody.AddForce(new Vector3(0, 1000, 0));
		}
	}
}
