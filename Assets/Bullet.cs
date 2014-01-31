using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	float time = 1;
	float Dir;
	//float side;
	
	// Use this for initialization
	void Start () {
		
		if (Globaal.direction)
		{
			Dir = 10;
			//side = 1;
		}
		
		if (Globaal.direction == false)
		{
			Dir = -10;
			//side = -1;
		}
		
		//transform.Translate(side, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (Dir * Time.deltaTime, 0, 0);
		time -= Time.deltaTime;
		
		if (time <= 0)
		{
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter (Collision col)
	{
		if (col.collider.name == "Vijand" || col.collider.name == "Vijand2(Clone)")
		{
			Globaal.getal += 10;
			Destroy(col.collider.gameObject);
			Destroy(gameObject);
		}
	}
}
