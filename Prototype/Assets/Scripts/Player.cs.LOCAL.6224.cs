using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Samurai))]
public class Player : MonoBehaviour {

    public Samurai MySamurai;
	public Animator MyAnimator;

	// Use this for initialization
	void Start () {
        MySamurai = GetComponent<Samurai>();
        MySamurai.IsPlayer = true;
		MyAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float horiz = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");
		MyAnimator.SetFloat("run", vert);

        // Left mouse button pressed
        if (Input.GetMouseButtonDown(0))
        {
			MyAnimator.SetBool("attack", true);
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
				MyAnimator.SetBool("attack", false);
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
