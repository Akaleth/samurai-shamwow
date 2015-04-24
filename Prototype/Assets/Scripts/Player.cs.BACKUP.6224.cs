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
        MySamurai.CreateActions(true);

        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		float horiz = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");
		MyAnimator.SetFloat("speed", vert);
		MyAnimator.SetFloat ("direction", horiz);

        // Left mouse button pressed
        if (Input.GetMouseButtonDown(0))
        {
			MyAnimator.SetBool("attack", true);
			Attack a = MySamurai.actions["Attack"] as Attack;
			if(a.ActionReady())
			{
				a.DoAction();
			}
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Dash d = MySamurai.actions["Dash"] as Dash;
            if (d.ActionReady())
            {
                d.DoAction();
            }
        }
		
        // TODO: Attacking, Dashing, and Interacting
        /*if (MySamurai.dashCooldownTimer < MySamurai.dashCooldown)
        {
            MySamurai.dashCooldownTimer += Time.deltaTime;
        }*/
        foreach (string k in MySamurai.actions.Keys)
        {
            MySamurai.actions[k].Update();
        }
        switch (MySamurai.CurrentBodyState)
        {
            case Samurai.BodyState.Idle:
				MyAnimator.SetBool("attack", false);
                break;
            case Samurai.BodyState.Attacking: // Tiger attack
                break;
            case Samurai.BodyState.Dashing: // Monkey attack
                break;
            case Samurai.BodyState.Parrying: // Crane
                break;
            case Samurai.BodyState.Stunned:

            default:
                break;
        }
	}
}
