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
            MySamurai.CurrentBodyState = MySamurai.BodyState.Dashing;
        }

        // TODO: Attacking, Dashing, and Interacting


        switch (MySamurai.CurrentBodyState)
        {
            case MySamurai.BodyState.Idle:
                break;
            case MySamurai.BodyState.Attacking:
                break;
            case MySamurai.BodyState.Dashing:
                if (MySamurai.dashTimer == MySamurai.dashTime)
                {
                    MySamurai.CurrentBodyState = MySamurai.BodyState.Idle;
                }
                else
                {

                }
                break;
            case MySamurai.BodyState.Parrying:
                break;
            case MySamurai.BodyState.Stunned:

            default:
                break;
        }
	}
}
