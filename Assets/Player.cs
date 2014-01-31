using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	bool standingPlatform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 speed = new Vector3();
		
		speed.y = rigidbody.velocity.y;
		
		if (Input.GetAxis("Horizontal") < 0)
		{
			speed.x = -10;
		} else if (Input.GetAxis("Horizontal") > 0){
			speed.x = 10;
		}
		
		if (Input.GetAxis("Jump") > 0 && standingPlatform)
		{
			rigidbody.AddForce(0, 300, 0);
		}
		
		rigidbody.velocity = speed;
		
		if (transform.position.y < -10)
		{
			Application.LoadLevel(0);
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.collider.name != "Enemy")
		{
			if (col.contacts[0].normal.y > 0.5f)
			{
				standingPlatform = true;
			}
		}
		
		if (col.collider.name == "Enemy")
		{
			if (col.contacts[0].normal.y > 0.8f)
			{
				Destroy(col.collider.gameObject);
			}
		}
	}
	
	void OnCollisionExit(Collision col)
	{
		if (col.collider.name != "Enemy")
		{
			standingPlatform = false;
		}
	}
}
