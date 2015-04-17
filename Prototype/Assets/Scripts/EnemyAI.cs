using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Samurai))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{

    private Samurai _samurai;
    private NavMeshAgent _agent;
    private Transform _target;

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

    private AttackPreference _currentAttackPreference = AttackPreference.RandomPlayer;

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
        _agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        _agent.SetDestination(AcquireTarget(_currentAttackPreference).transform.position);
	}
}
