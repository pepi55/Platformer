using UnityEngine;
using System.Collections;

public class Vijand : MonoBehaviour {
	int richting = 1;
	
	public bool follows;
	private float speed = 5f;
	
	void FixedUpdate () {
		if (follows)
		{
			Follow();
		}
				
		Vector3 snelheid = new Vector3();
		
		snelheid.y = rigidbody.velocity.y;
		
		snelheid.x = speed * richting;
		
		rigidbody.velocity = snelheid;
		
		if (transform.position.y < -5)
		{
			DestroyObject(gameObject);
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.collider.name == "Vijand" || col.collider.name == "Vijand2(Clone)")
		{
			richting = -richting;	
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		//if (col.name == "Edge")
		
		if (col.name == "Edge")
		{
			if (follows)
			{
				transform.Translate(0.25f * -richting, 0, 0);
			} else {
				richting = -richting;
			}
		}
	}
	
	void Follow()
	{
		GameObject player = GameObject.Find("Speler");
		
		if (player.transform.position.x > transform.position.x)
		{
			richting = 1;
		}
		else {
			richting = -1;
		}
	}
}
