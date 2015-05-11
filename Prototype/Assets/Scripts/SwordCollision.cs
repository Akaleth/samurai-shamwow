using UnityEngine;
using System.Collections;

public class SwordCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisonEnter(Collision col)
	{
		if(col.gameObject.name == "Samurai")
		{
			// deal damage to target based on tiger stat

		}
		Debug.Log("BLAP BLAP");
	}
}
