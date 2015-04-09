using UnityEngine;

public class Samurai : MonoBehaviour {

    public int Tiger;
    public int Monkey;
    public int Crane;
    public int Honor;
    public int Glory;

    public int Health;

    public enum BodyState
    {
        Charging, Attacking, Running, Dashing, Idle
    }

    public GameObject chargeTarget;
    public bool hasTarget;

    public Vector3 attackTarget;

    public BodyState CurrentBodyState;

    public double attackTimer = 0.0;

	// Use this for initialization
	void Start () {
        Health = 2;
        Tiger = Honor = Glory = Monkey = Crane = 1;
        CurrentBodyState = BodyState.Idle;
        chargeTarget = null;
        hasTarget = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Charge()
    {
        if (!hasTarget)
            if (lockOn())
                CurrentBodyState = BodyState.Charging;
    }

    public void Attack()
    {
        if (hasTarget)
        {
            attackTarget = chargeTarget.transform.position;
            transform.LookAt(attackTarget);

            CurrentBodyState = BodyState.Attacking;

            chargeTarget = null;
        }
    }

    public void Dash()
    {

    }

    public void Interact()
    {

    }

    public bool lockOn()
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

    public void lockOff()
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

    public float GetAttackSpeed()
    {
        // For now...
        return Tiger * 50.0f;
    }

    
}
