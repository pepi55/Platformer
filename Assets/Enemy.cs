using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	int richting = 1;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 speed = new Vector3();
		
		speed.y = rigidbody.velocity.y;
		speed.x = 10 * richting;
		rigidbody.velocity = speed;
	}
	
	void OnTriggerEnter()
	{
		richting = -richting;
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.collider.name == "Enemy")
		{
			richting = -richting;
		}
	}
}
