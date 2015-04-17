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

    public float GetAttackSpeed()
    {
        // For now...
        return Tiger * 50.0f;
    }

    
}
