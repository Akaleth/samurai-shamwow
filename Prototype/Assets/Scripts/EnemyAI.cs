using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Samurai))]
public class EnemyAI : MonoBehaviour
{

    private Samurai _samurai;

    public enum AttackPreference
    {
        ClosestPlayer,
        ClosestVillager,
        WeakestPlayer,
        RandomPlayer,
        RandomVillager,
        Blacksmith,
        Tavern,
        Library
    }

    public GameObject AcquireTarget(AttackPreference pref)
    {
        switch (pref)
        {
            
        }
        return null;
    }

    // Use this for initialization
	void Start () {
        _samurai = GetComponent<Samurai>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
