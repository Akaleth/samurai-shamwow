using UnityEngine;
using System.Collections;

public class Attack : Action {

	public Attack(float cooldown, float duration, Samurai owner, bool playerAction) : base(cooldown, duration, owner, playerAction)
    {

    }

	// Use this for initialization
	public override void DoAction()
    {
        base.DoAction();
        owner.CurrentBodyState = Samurai.BodyState.Attacking;
		Transform[] children = owner.GetComponentsInChildren<Transform>();
		foreach(Transform child in children)
		{
			if (child.gameObject.name == "Sword")
			{
				child.GetComponent<BoxCollider>().enabled = true;
			}
		}
	}
	
	// Update is called once per frame
	public override void Update() 
    {
        base.Update();
        if (active)
        {

        }
	}

    public override void End()
    {
        base.End();
		Transform[] children = owner.GetComponentsInChildren<Transform>();
		foreach(Transform child in children)
		{
			if (child.gameObject.name == "Sword")
			{
				child.GetComponent<BoxCollider>().enabled = false;
			}
		}
    }
}
