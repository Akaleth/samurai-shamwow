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

	protected Vector3 attackTarget;

    protected BodyState CurrentBodyState;

	protected double attackTimer = 0.0;

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
        }

        // TODO: Attacking, Dashing, and Interacting

        //if(hasTarget)
           // transform.LookAt(chargeTarget.transform);


		switch (CurrentBodyState)
		{
			case BodyState.Charging:
				transform.LookAt(chargeTarget.transform);
			    
			    if (Input.GetKeyDown(KeyCode.T))
				{
					Attack();
					lockOff();
				}
				break;
			case BodyState.Attacking:
			    transform.LookAt(attackTarget);

			    GetComponent<CharacterController>().Move((attackTarget - transform.position).normalized * Time.deltaTime * 50);
			    attackTimer += Time.deltaTime;

			    if(Vector3.Distance(attackTarget, transform.position) <= 5 || attackTimer >= 5.0 || Input.GetKeyDown(KeyCode.T))
				{
					CurrentBodyState = BodyState.Idle;
					attackTarget = Vector3.zero;
				    attackTimer = 0;
				}
				break;
			case BodyState.Running:
				break;
			case BodyState.Dashing:
				break;
			case BodyState.Idle:
				break;
			default:
				break;
		}

	}

    void Charge()
    {
        if (!hasTarget)
            if (lockOn())
                CurrentBodyState = BodyState.Charging;
    }

    void Attack()
    {
        if (hasTarget) 
		{
			attackTarget = chargeTarget.transform.position;
			transform.LookAt(attackTarget);

			CurrentBodyState = BodyState.Attacking;

			chargeTarget = null;
		}
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
