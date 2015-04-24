using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Samurai : MonoBehaviour {

    public bool IsPlayer = false;

    public int Tiger;
    public int Monkey;
    public int Crane;
    //public int Honor;
    //public int Glory;

    public float dashTimer;
    public float dashTime;
    public float dashCooldown;
    public float dashCooldownTimer;

    public int Health;
    public Action currentAction;
    public Dictionary<string, Action> readyActions;

    public Dictionary<string, Action> actions;

    public enum BodyState
    {
        Idle, Attacking, Dashing, Parrying, Stunned,
    }

    public BodyState CurrentBodyState;

	// Use this for initialization
	void Start () {
        Health = 2;
        Tiger = /*Honor = Glory = */Monkey = Crane = 1;
        CurrentBodyState = BodyState.Idle;
        dashTime = 0.3f;
        dashTimer = 0.0f;
        dashCooldown = 2.0f;
        dashCooldownTimer = 2.0f;
        CreateActions(false);
	}
	
	// Update is called once per frame
	void Update () {
	
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
		Attack a = new Attack (1.5f, 0.3f, this, playerAction);
    }

    
}
