using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPoint : MonoBehaviour
{
    public GameObject BasicEnemy;
    public int NumEnemies = 10;
    public float NightDurationMinutes = 1.0f;
    public int EnemiesPerGroup = 2;
    private float _secondsPerEnemyGroup
    {
        get
        {
            return (NightDurationMinutes * 60.0f) / NumEnemies;
        }
    }

    private float spawnTimer = 0.0f;
    private List<TestEnemy> _spawnList;

    private void Spawn()
    {
        Instantiate(BasicEnemy, this.transform.position, this.transform.rotation);
    }

    // Use this for initialization
	void Start () {
        _spawnList = new List<TestEnemy>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= _secondsPerEnemyGroup)
        {
            spawnTimer = 0.0f;
            Spawn();
        }
	}
}
