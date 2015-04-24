using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Samurai))]
public class Player : MonoBehaviour {

    public Samurai MySamurai;

	// Use this for initialization
	void Start () {
        MySamurai = GetComponent<Samurai>();
        MySamurai.IsPlayer = true;
	}
	
	// Update is called once per frame
	void Update () {
        // Left mouse button pressed
        if (Input.GetMouseButtonDown(0))
        {
            MySamurai.Attack();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            MySamurai.CurrentBodyState = Samurai.BodyState.Dashing;
        }

        // TODO: Attacking, Dashing, and Interacting


        switch (MySamurai.CurrentBodyState)
        {
            case Samurai.BodyState.Idle:
                break;
            case Samurai.BodyState.Attacking:
                break;
            case Samurai.BodyState.Dashing:
                if (MySamurai.dashTimer == MySamurai.dashTime)
                {
                    MySamurai.CurrentBodyState = Samurai.BodyState.Idle;
                }
                else
                {

                }
                break;
            case Samurai.BodyState.Parrying:
                break;
            case Samurai.BodyState.Stunned:

            default:
                break;
        }
	}
}
