using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Samurai))]
public class Player : MonoBehaviour {

    private Samurai MySamurai;

	// Use this for initialization
	void Start () {
        MySamurai = GetComponent<Samurai>();
        MySamurai.IsPlayer = true;
        MySamurai.CreateActions(true);

        Cursor.visible = false;
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
