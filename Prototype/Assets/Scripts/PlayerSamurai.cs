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

    protected GameObject chargeTarget;
    protected bool hasTarget;

    protected BodyState CurrentBodyState;

    // Use this for initialization
	void Start ()
	{
	    Health = 2;
	    Might = Honor = Glory = Cunning = Wisdom = 1;
        CurrentBodyState = BodyState.Idle;
        chargeTarget = null;
        hasTarget = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Left mouse button pressed
        if (Input.GetMouseButtonDown(0))
        {
            if(!hasTarget)
                Charge();
            /*switch (CurrentBodyState)
            {
                case BodyState.Charging:
                    transform.LookAt(chargeTarget.transform);
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
            }*/
        }

        if (Input.GetKey(KeyCode.T))
        {
            lockOff();
        }

        // TODO: Attacking, Dashing, and Interacting

        if(hasTarget)
            transform.LookAt(chargeTarget.transform);
	}

    void Charge()
    {
        if (!hasTarget)
            if (lockOn())
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

    bool lockOn()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            chargeTarget = hit.collider.gameObject;
            hasTarget = true;

            CharacterMotor cm = GetComponent<CharacterMotor>();
            cm.movement.maxForwardSpeed = 3;
            cm.movement.maxBackwardsSpeed = 3;
            cm.movement.maxSidewaysSpeed = 3;

            return true;
        }
        return false;
    }

    void lockOff()
    {
        chargeTarget = null;
        hasTarget = false;

        CharacterMotor cm = GetComponent<CharacterMotor>();
        cm.movement.maxForwardSpeed = 10;
        cm.movement.maxBackwardsSpeed = 10;
        cm.movement.maxSidewaysSpeed = 10;

        // add force/something to shoot player towards the target's location at the time of the attack
        // ask Chris about this; apply force maybe, but currently no rigidbody on it, maybe easier way
    }
}
