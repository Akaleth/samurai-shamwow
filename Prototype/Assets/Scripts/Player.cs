using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Samurai))]
public class Player : MonoBehaviour {

    public bool stealthed;
    private float stealthCooldown;
    private float stealthCooldownTimer;

    private Samurai MySamurai;
	public Animator MyAnimator;

	// Use this for initialization
	void Start () {
        MySamurai = GetComponent<Samurai>();
        MySamurai.IsPlayer = true;
        MySamurai.CreateActions(true);

        Cursor.visible = false;
        stealthed = false;
        stealthCooldown = 10.0f;
        stealthCooldownTimer = 10.0f;
		MyAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (stealthCooldownTimer <= stealthCooldown && !stealthed)
        {
            stealthCooldownTimer += Time.deltaTime;
        }

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
            Dash d = MySamurai.actions["Dash"] as Dash;
            if (d.ActionReady())
            {
                d.DoAction();
                StealthOff();
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && stealthCooldownTimer >= stealthCooldown)
        {
            StealthOn();
        }

        foreach (string k in MySamurai.actions.Keys)
        {
            MySamurai.actions[k].Update();
        }
		
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
            case Samurai.BodyState.Stunned: // Crane parry
                break;
            default:
                break;
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

    void StealthOn()
    {
        if (!stealthed)
        {
            stealthed = true;
            MySamurai.GetComponent<CharacterMotor>().movement.maxForwardSpeed = 15.0f;
        }
    }

    void StealthOff()
    {
        if (stealthed)
        {
            stealthed = false;
            MySamurai.GetComponent<CharacterMotor>().movement.maxForwardSpeed = 10.0f;
            stealthCooldownTimer = 0.0f;
        }
    }
}
