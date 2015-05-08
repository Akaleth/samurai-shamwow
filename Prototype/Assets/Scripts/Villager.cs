using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Villager : MonoBehaviour {


    public const float VILLAGER_WANDER_RADIUS = 40.0f;
    public const float VILLAGER_WANDER_FREQUENCY = 1.0f;

    private float _wanderTimer = 0.0f;
    private NavMeshAgent _agent;

	// Use this for initialization
	void Start () {
        //gameObject.SetActive(false);
        _agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        _wanderTimer += Time.deltaTime;
        if (_wanderTimer >= VILLAGER_WANDER_FREQUENCY)
        {
            AssignWanderDestination();
            _wanderTimer = Random.Range(0, VILLAGER_WANDER_FREQUENCY / 2.0f);
        }
	}

    private void AssignWanderDestination()
    {
        if (_agent == null)
        {
            return;
        }
        var randomDirection = Random.insideUnitSphere * VILLAGER_WANDER_RADIUS;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, VILLAGER_WANDER_RADIUS, 1);
        _agent.SetDestination(hit.position);
    }
}
