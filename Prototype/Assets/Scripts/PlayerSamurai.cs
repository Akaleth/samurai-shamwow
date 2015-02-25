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
        Charging, Attacking, Running, Dashing, Idle
    }

    protected BodyState CurrentBodyState;

    // Use this for initialization
	void Start ()
	{
	    Health = 2;
	    Might = Honor = Glory = Cunning = Wisdom = 1;
        CurrentBodyState = BodyState.Idle;
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Left mouse button pressed
        if (Input.GetMouseButtonDown(0))
        {
            switch (CurrentBodyState)
            {
                case BodyState.Charging:
                    break;
                case BodyState.Attacking:
                    break;
                case BodyState.Running:
                    Charge();
                    break;
                case BodyState.Dashing:
                    Charge();
                    break;
                case BodyState.Idle:
                    Charge();
                    break;
                default:
                    break;
            }
        }
        // TODO: Attacking, Dashing, and Interacting
	        

	}

    void Charge()
    {
        CurrentBodyState = BodyState.Charging;
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
