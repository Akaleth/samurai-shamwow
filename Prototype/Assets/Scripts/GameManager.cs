using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{

    public Player Player1;
    public Player Player2;
    public Player Player3;
    public Player Player4;

    public static List<Samurai> Players;
    public static int NumPlayers = 4;

    public GameObject Blacksmith;
    public GameObject Library;
    public GameObject Tavern;

    public static GameObject ClosestPlayer(GameObject caller)
    {
        return null;
    }

    public static GameObject ClosestVillager(GameObject caller)
    {
        return null;
    }

    public static GameObject WeakestPlayer(GameObject caller)
    {
        return null;
    }

    public static GameObject RandomPlayer(GameObject caller)
    {
        return Players.Where(x => x.IsPlayer).ElementAt(Random.Range(0, NumPlayers)).transform.gameObject;
    }

    public static GameObject RandomVilager(GameObject caller)
    {
        return null;
    }

	// Use this for initialization
	void Start () 
    {
        Players = new List<Samurai> { Player1.MySamurai, Player2.MySamurai, Player3.MySamurai, Player4.MySamurai };
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
