using UnityEngine;
using System.Collections;

public class SwordCollision : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider col)
	{
        if ((col.gameObject.GetComponent<EnemyAI>() && !gameObject.GetComponent<EnemyAI>()) || (!col.gameObject.GetComponent<EnemyAI>() && gameObject.GetComponent<EnemyAI>()))
		{
			var anim = player.GetComponent<Animator>();
			if(anim.GetFloat("swordActivation") >= 0.95)
			{
				Debug.Log("BLAP BLAP FOR REAL");
				col.gameObject.GetComponent<Samurai>().GetComponent<Health>().TakeDamage(1);
			}
			// deal damage to target based on tiger stat

		}
	}
}
