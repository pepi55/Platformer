using UnityEngine;
using System.Collections;

public class Punten : MonoBehaviour {
	
	//float teller;
	
	void Update ()
	{
		//teller += Time.deltaTime;
		
		guiText.text = Globaal.getal.ToString();
	}
}
