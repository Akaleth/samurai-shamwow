using UnityEngine;
using System.Collections.Generic;

public class CraneShield : MonoBehaviour {

    public float Duration = 3.0f;

    public float ShieldSize = 20.0f;
    //public bool isActive = false;

    public NavMeshObstacle _front;
    public NavMeshObstacle _back;
    public NavMeshObstacle _left;
    public NavMeshObstacle _right;

    private List<NavMeshObstacle> _walls
    {
        get
        {
            return new List<NavMeshObstacle> {_front, _back, _left, _right};
        }
    }

	// Use this for initialization
	void Start () {
        SetupWalls();
        //Disable();
	}

    void LateUpdate()
    {
        ResetRotation();
    }

    private void PutShieldDown()
    {
        transform.parent = null;
    }

    private void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void Enable()
    {
        _walls.ForEach(x => x.enabled = true);
    }

    private void Disable()
    {
        _walls.ForEach(x => x.enabled = false);
    }

    private void SetupWalls()
    {
        _front.shape = _back.shape = _left.shape = _right.shape = NavMeshObstacleShape.Box;

        _front.center = new Vector3(0, 0, ShieldSize / 2);

        _back.center = new Vector3(0, 0, -ShieldSize / 2);

        _front.size = _back.size = new Vector3(ShieldSize, 2, 1);

        _left.center = new Vector3(-ShieldSize / 2, 0, 0);

        _right.center = new Vector3(ShieldSize / 2, 0, 0);

        _left.size = _right.size = new Vector3(1, 2, ShieldSize);
    }
	
	// Update is called once per frame
	void Update () {
        Duration -= Time.deltaTime;
        if (Duration <= 0)
        {
            Disable();
        }
	}
}
