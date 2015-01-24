using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    [SerializeField]
    private WorldManager Manager;

    private float Speed = 2.5f;
    private float positionThreshold = .1f;

    private Vector3 TargetPosition;
    private bool IsMoving = false;

    

    public void SetTargetPosition(Vector3 target)
    {
        TargetPosition = target;
        IsMoving = true;
    }

	// Use this for initialization
	void Start () {
        IsMoving = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (IsMoving)
        { 
            Vector3 curPos = transform.position;
            Vector3 displacement = (TargetPosition - curPos).normalized * Speed * Time.deltaTime;
            Vector3 nextPos = transform.position + displacement;
            if ((TargetPosition - nextPos).magnitude < positionThreshold)
            {
                transform.position = TargetPosition;
                IsMoving = false;
            }
            else {
                transform.position = transform.position + displacement;
                
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        Manager.NotifyTriggerHit(other);
    }
}
