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

    public static List<Villager> Villagers;
    public static int NumVillagers = 40;

    public static GameObject Blacksmith;
    public static GameObject Library;
    public static GameObject Tavern;

    /// <summary>
    /// Returns the length of a given path;
    /// </summary>
    /// <param name="from">The path to measure</param>
    /// <returns></returns>
    public static float PathDistance(NavMeshPath from)
    {
        if (from.corners.Length < 2)
            return 0;

        Vector3 previousCorner = from.corners[0];
        float lengthSoFar = 0.0F;
        int i = 1;
        while (i < from.corners.Length)
        {
            Vector3 currentCorner = from.corners[i];
            lengthSoFar += Vector3.Distance(previousCorner, currentCorner);
            previousCorner = currentCorner;
            i++;
        }
        return lengthSoFar;
    
    }

    public static GameObject ClosestPlayer(GameObject caller)
    {
        NavMeshAgent agent = caller.GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            return null;
        }
        
        NavMeshPath path = null;
        GameObject closest = null;
        float closestDist = float.MaxValue;

        foreach (var player in Players)
        {
            if (!agent.CalculatePath(player.transform.position, path))
            {
                return null;
            }
            if (PathDistance(path) < closestDist)
            {
                closestDist = PathDistance(path);
                closest = player.transform.gameObject;
            }
        }
        return closest;
    }

    public static GameObject ClosestVillager(GameObject caller)
    {
        NavMeshAgent agent = caller.GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            return null;
        }

        NavMeshPath path = null;
        GameObject closest = null;
        float closestDist = float.MaxValue;

        foreach (var villager in Villagers)
        {
            if (!agent.CalculatePath(villager.transform.position, path))
            {
                return null;
            }
            if (PathDistance(path) < closestDist)
            {
                closestDist = PathDistance(path);
                closest = villager.transform.gameObject;
            }
        }
        return closest;
    }

    public static GameObject WeakestPlayer(GameObject caller)
    {
        return Players.OrderBy(x => x.Health).ElementAt(0).transform.gameObject;
    }

    public static GameObject RandomPlayer(GameObject caller)
    {
        return Players.Where(x => x.IsPlayer).ElementAt(Random.Range(0, NumPlayers)).transform.gameObject;
    }

    public static GameObject RandomVillager(GameObject caller, float range)
    {
        Collider[] nearbyVillagers = Physics.OverlapSphere(caller.transform.position, range);
        if (nearbyVillagers.Count() == 0)
            return null;
        return nearbyVillagers.Where(x => x.GetComponent<Villager>() != null).ElementAt(Random.Range(0, NumVillagers)).transform.gameObject;
    }

	// Use this for initialization
	void Start () 
    {
        Villagers = new List<Villager>().Where(x => x.tag == "Villager").ToList();
        Players = new List<Samurai> { Player1.MySamurai, Player2.MySamurai, Player3.MySamurai, Player4.MySamurai };
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
