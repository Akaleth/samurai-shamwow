using UnityEngine;
using System.Collections;

public class TestEnemy : MonoBehaviour {

    private NavMeshAgent _agent;
    public GameObject Player;

	// Use this for initialization
	void Start () {
        _agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        _agent.SetDestination(Player.transform.position);
	}
}
