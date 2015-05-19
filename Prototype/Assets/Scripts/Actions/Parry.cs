using UnityEngine;
using System.Collections;

public class Parry : Action {

	public Parry(float cooldown, float duration, Samurai owner, bool playerAction) : base(cooldown, duration, owner, playerAction)
    {

    }
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}

	public override void DoAction()
	{
		base.DoAction ();
        owner.parrying = true;
        owner.CurrentBodyState = Samurai.BodyState.Parrying;
	}

    public override void End()
    {
        owner.parrying = false;
        base.End();
    }
}
