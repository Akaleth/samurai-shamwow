using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Samurai))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{

    private Samurai _samurai;
    private NavMeshAgent _agent;
    private GameObject _target;
    private bool _targetSet = false;

    public enum EnemyType
    {
        Tiger,
        Monkey,
        Crane
    }

    private EnemyType _type;

    public float perceptionRange = 50.0f;

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
            case AttackPreference.Blacksmith:
                return GameManager.Blacksmith;
            case AttackPreference.Library:
                return GameManager.Library;
            case AttackPreference.Tavern:
                return GameManager.Tavern;
            case AttackPreference.RandomPlayer:
                return GameManager.RandomPlayer(this.gameObject);
            case AttackPreference.RandomVillager:
                return GameManager.RandomVillager(this.gameObject, perceptionRange);
            case AttackPreference.ClosestPlayer:
                return GameManager.ClosestPlayer(this.gameObject);
            case AttackPreference.ClosestVillager:
                return GameManager.ClosestVillager(this.gameObject);
            case AttackPreference.WeakestPlayer:
                return GameManager.WeakestPlayer(this.gameObject);
        }
        return null;
    }

    // Use this for initialization
	void Start () {
        _samurai = GetComponent<Samurai>();
        _agent = GetComponent<NavMeshAgent>();

        var possibleTypes = Enum.GetValues(typeof(EnemyType));
        _type = (EnemyType)possibleTypes.GetValue(UnityEngine.Random.Range(0, possibleTypes.Length));

        _currentAttackPreference = AttackPreference.RandomPlayer;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!_targetSet)
        {
            _target = AcquireTarget(_currentAttackPreference);
            if (_target != null)
                _agent.SetDestination(_target.transform.position);
            _targetSet = true;
        }
        else
        {
            _agent.SetDestination(_target.transform.position);
        }
	}
}
