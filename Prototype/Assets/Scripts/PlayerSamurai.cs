using UnityEngine;
using System.Collections;

public class PlayerSamurai : MonoBehaviour
{

    public int Might;
    public int Honor;
    public int Glory;
    public int Cunning;
    public int Wisdom;

    public int Health;

    public enum BodyState
    {
        Attacking, Running, Dashing, Idle
    }

    protected BodyState CurrentBodyState;

    // Use this for initialization
	void Start ()
	{
	    Health = 2;
	    Might = Honor = Glory = Cunning = Wisdom = 1;
	}
	
	// Update is called once per frame
	void Update () {

	    

	}

    void Attack()
    {
        
    }

    void Dash()
    {
        
    }

    void Interact()
    {
        
    }
}
