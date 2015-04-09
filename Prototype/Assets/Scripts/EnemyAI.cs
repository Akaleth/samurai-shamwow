using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

    public GameObject EnemyGameObject;

    public enum ObjectiveValue
    {
        BurnCrops,
        KillElder,
        KillVillagers,
        KillPlayers
    }

    public ObjectiveValue Objective;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
