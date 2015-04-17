using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Samurai))]
public class Player : MonoBehaviour {

    Samurai _samurai;

	// Use this for initialization
	void Start () {
        _samurai = GetComponent<Samurai>();
	}
	
	// Update is called once per frame
	void Update () {
        // Left mouse button pressed
        if (Input.GetMouseButtonDown(0))
        {
            _samurai.Attack();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _samurai.CurrentBodyState = Samurai.BodyState.Dashing;
        }

        // TODO: Attacking, Dashing, and Interacting


        switch (_samurai.CurrentBodyState)
        {
            case Samurai.BodyState.Idle:
                break;
            case Samurai.BodyState.Attacking:
                break;
            case Samurai.BodyState.Dashing:
                if (_samurai.dashTimer == _samurai.dashTime)
                {
                    _samurai.CurrentBodyState = Samurai.BodyState.Idle;
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
