using UnityEngine;
using System.Collections;

public class Action 
{
    protected float cooldown;
    protected float cooldownTimer;
    protected float duration;
    protected float durationTimer;
    protected Samurai owner;
    public bool active;
    public bool playerAction;

    public Action(float cooldown, float duration, Samurai owner, bool playerAction)
    {
        this.cooldown = cooldown;
        this.cooldownTimer = cooldown;

        this.duration = duration;
        this.durationTimer = 0.0f;
        this.owner = owner;
        active = false;
        this.playerAction = playerAction;
    }

	// Use this for initialization
	public virtual void DoAction()
    {
        if (!active && cooldownTimer >= cooldown && owner.currentAction == null)
        {
            active = true;
            cooldownTimer = 0.0f;
            owner.currentAction = this;
        }
	}
	
	// Update is called once per frame
	public virtual void Update() 
    {
        if (active)
        {
            if (durationTimer >= duration)
                End();
            else
                durationTimer += Time.deltaTime;
        }
        else
        {
            cooldownTimer += Time.deltaTime;
        }
	}

    public virtual void End()
    {
        owner.CurrentBodyState = Samurai.BodyState.Idle;
        durationTimer = 0.0f;
        active = false;
        owner.currentAction = null;
    }

    public virtual bool ActionReady()
    {
        return cooldownTimer >= cooldown;
    }
}
