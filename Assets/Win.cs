using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Globaal.won)
		{
			Application.LoadLevel ("Scene2");
		}
	}
}