using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Samurai))]
public class Player : MonoBehaviour {

    public bool stealthed;
    private float stealthCooldown;
    private float stealthCooldownTimer;

    private Samurai MySamurai;

	// Use this for initialization
	void Start () {
        MySamurai = GetComponent<Samurai>();
        MySamurai.IsPlayer = true;
        MySamurai.CreateActions(true);

        Cursor.visible = false;
        
        stealthCooldown = 10.0f;
        stealthCooldownTimer = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (stealthCooldownTimer <= stealthCooldown && !stealthed)
        {
            stealthCooldownTimer += Time.deltaTime;
        }

        // Left mouse button pressed
        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire2"))
        {
            MySamurai.DoTiger();
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire3"))
        {
            MySamurai.DoMonkey();
        }

        if (Input.GetKeyDown(KeyCode.R) && stealthCooldownTimer >= stealthCooldown)
        {
            MySamurai.StealthOn();
        }
	}



    
}
