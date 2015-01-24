using UnityEngine;
using System.Collections;

public class RoomObjectScript : MonoBehaviour {

    [SerializeField]
    private WorldManager Manager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Manager.NotifyTriggerHit(other);
    }
}
