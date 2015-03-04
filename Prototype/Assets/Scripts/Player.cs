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
            if (!_samurai.hasTarget)
                _samurai.Charge();
        }

        // TODO: Attacking, Dashing, and Interacting

        if (_samurai.hasTarget)
            transform.LookAt(_samurai.chargeTarget.transform);


        switch (_samurai.CurrentBodyState)
        {
            case Samurai.BodyState.Charging:
                transform.LookAt(_samurai.chargeTarget.transform);

                if (Input.GetKeyDown(KeyCode.T))
                {
                    _samurai.Attack();
                    _samurai.lockOff();
                }
                break;
            case Samurai.BodyState.Attacking:
                transform.LookAt(_samurai.attackTarget);

                GetComponent<CharacterController>().Move((_samurai.attackTarget - transform.position).normalized * Time.deltaTime * 50);
                _samurai.attackTimer += Time.deltaTime;

                if (Vector3.Distance(_samurai.attackTarget, transform.position) <= 5 || _samurai.attackTimer >= 5.0 || Input.GetKeyDown(KeyCode.T))
                {
                    _samurai.CurrentBodyState = Samurai.BodyState.Idle;
                    _samurai.attackTarget = Vector3.zero;
                    _samurai.attackTimer = 0;
                }
                break;
            case Samurai.BodyState.Running:
                break;
            case Samurai.BodyState.Dashing:
                break;
            case Samurai.BodyState.Idle:
                break;
            default:
                break;
        }
	}
}
