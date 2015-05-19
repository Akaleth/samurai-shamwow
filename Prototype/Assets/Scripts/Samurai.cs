using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Samurai : MonoBehaviour {

    public bool IsPlayer = false;

	public InvulnFrames iframes;

    public int Tiger;
    public int Monkey;
    public int Crane;
    //public int Honor;
    //public int Glory;
    private int fieldOfView;

    bool stealthed = false;
    private float stealthCooldown;
    private float stealthCooldownTimer;

    public Action currentAction;
    public Dictionary<string, Action> readyActions;

    public Dictionary<string, Action> actions;

	private bool isAlive;
	public Animator MyAnimator;

    public enum BodyState
    {
        Idle, Attacking, Dashing, Parrying, Stunned,
    }

    public BodyState CurrentBodyState;

	// Use this for initialization
	void Start () {
        Tiger = /*Honor = Glory = */Monkey = Crane = 1;
        CurrentBodyState = BodyState.Idle;
        CreateActions(false);
        fieldOfView = 60;
		isAlive = true;

        MyAnimator = GetComponent<Animator>();
		iframes = GetComponent<InvulnFrames>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Health>().health == 0)
			Die();


        foreach (string k in actions.Keys)
        {
            actions[k].Update();
        }

        switch (CurrentBodyState)
        {
            case Samurai.BodyState.Idle:
                MyAnimator.SetBool("attack", false);
                MyAnimator.SetBool("dash", false);
                break;
            case Samurai.BodyState.Attacking:
                MyAnimator.SetBool("attack", true);
                break;
            case Samurai.BodyState.Dashing:
                MyAnimator.SetBool("dash", true);
                break;
            case Samurai.BodyState.Parrying:
                break;
            case Samurai.BodyState.Stunned: // Crane parry
                break;
            default:
                break;
        }
	}

    public void Charge()
    {

    }

    public void Attack()
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

    public void CreateActions(bool playerAction)
    {
        actions = new Dictionary<string, Action>();
        Dash d = new Dash(1.5f, 0.3f, this, playerAction);
        actions.Add("Dash", d);
		Attack a = new Attack (1.5f, 0.6f, this, playerAction);
		actions.Add("Attack", a);
    }

    public int GetFieldOfView()
    {
        return fieldOfView;
    }


	public void Die()
	{
		isAlive = false;
		MyAnimator.SetBool("death", true);
		//Destroy (this.gameObject);
	}

	public void DestroySamurai()
	{
		Destroy (this.gameObject);
	}

    public void StealthOn()
    {
        if (!stealthed)
        {
            stealthed = true;
            GetComponent<CharacterMotor>().movement.maxForwardSpeed = 15.0f;
        }
    }

    public void StealthOff()
    {
        if (stealthed)
        {
            stealthed = false;
            GetComponent<CharacterMotor>().movement.maxForwardSpeed = 10.0f;
            stealthCooldownTimer = 0.0f;
        }
    }

    public void DoTiger()
    {
        Attack a = actions["Attack"] as Attack;
        if (a.ActionReady())
        {
            a.DoAction();
            StealthOff();
        }
    }

    public void DoMonkey()
    {
        Dash d = actions["Dash"] as Dash;
        if (d.ActionReady())
        {
            d.DoAction();
            StealthOff();
        }
    }

    void CheckMonkeyHit(Samurai target)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(GetComponent<Camera>());
        Collider collider = target.GetComponent<Collider>();

        if (GeometryUtility.TestPlanesAABB(planes, collider.bounds))
        {
            if (Vector3.Angle(target.transform.forward, target.transform.position - this.transform.position) <= target.GetFieldOfView() / 2)
            {
                // Monkey hit is successful
                // target.TakeDamage(monkeyDamage);
            }
        }
    }
}
