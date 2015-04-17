using UnityEngine;

public class Samurai : MonoBehaviour {

    public bool IsPlayer = false;

    public int Tiger;
    public int Monkey;
    public int Crane;
    //public int Honor;
    //public int Glory;

    public int dashTimer;
    public int dashTime;

    public int Health;

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
        dashTime = 100;
        dashTimer = 0;
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
