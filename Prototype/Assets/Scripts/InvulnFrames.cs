using UnityEngine;
using System.Collections;

public class InvulnFrames : MonoBehaviour {

	public float duration;
	private float durationCounter;
	public SkinnedMeshRenderer mesh;
	public bool enabled;

	// Use this for initialization
	void Start () {
		enabled = false;
		//mesh = GetComponentInChildren<SkinnedMeshRenderer>();
		duration = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(enabled)
		{
			if(durationCounter <= duration)
				durationCounter += Time.deltaTime;
			if(mesh)
			{
				Color c = mesh.material.color;
				//c.a = Mathf.Sin (durationCounter)/2 + 0.5f;
				//c.a = 0;
				//mesh.material.SetColor(0, c);
				mesh.enabled = Mathf.Sin (durationCounter * 20) > 0 ? true : false;
			}
			if(durationCounter >= duration)
			{
				enabled = false;
				mesh.enabled = true;
				durationCounter = 0;
			}
		}
	}
}
