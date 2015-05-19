using UnityEngine;
using System.Collections;

public class Dash : Action {

	public Dash(float cooldown, float duration, Samurai owner, bool playerAction) : base(cooldown, duration, owner, playerAction)
    {

    }

	// Use this for initialization
	public override void DoAction()
    {
        base.DoAction();
        owner.CurrentBodyState = Samurai.BodyState.Dashing;
        if (playerAction)
        {
            owner.GetComponent<Player>().GetComponent<MouseLook>().sensitivityX = 1.0f;
            owner.GetComponent<Player>().GetComponent<MouseLook>().sensitivityY = 1.0f;
        }
	}
	
	// Update is called once per frame
	public override void Update() 
    {
        base.Update();
        if (active)
        {
            Vector3 moveDir = owner.transform.forward;
            moveDir.y = 0.0f;
            owner.transform.position += moveDir * 6f * Time.deltaTime;
        }
	}

    public override void End()
    {
        base.End();
        if (playerAction)
        {
            owner.GetComponent<Player>().GetComponent<MouseLook>().sensitivityX = 2.5f;
            owner.GetComponent<Player>().GetComponent<MouseLook>().sensitivityY = 2.5f;
        }
    }
}
