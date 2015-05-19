using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public Samurai samurai;
	public int health;

	// Use this for initialization
	void Start () {
		health = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		samurai.iframes.enabled = true;
	}

}
