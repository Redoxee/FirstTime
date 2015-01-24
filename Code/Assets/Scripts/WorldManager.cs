using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldManager : MonoBehaviour {


    private float minY = -3;
    private float maxY = 0;

    private float characterDepth = -1.0f;

    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    private GUIManager GUIManager;

    [SerializeField]
    private Character P1;

    private GameObject CurrentItem;


    private void InitDictionary()
    {
    }

	// Use this for initialization
	void Start () {

        Vector3 p1InitPos = new Vector3(-0.5f,-0.5f,characterDepth);
        P1.transform.position = p1InitPos;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 tpos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            float y = Mathf.Clamp(tpos.y, minY, maxY);
            tpos.y = y;
            tpos.z = characterDepth;

            P1.SetTargetPosition(tpos);
        }
	}

    public void NotifyTriggerHit(Collider other)
    {

        var ros = other.GetComponentInParent<RoomObjectScript>();
        var objectName = ros.RoomObjectName;
        if (objectName == "Closet")
        { 
            ClosetComportment();
        }
        else if (objectName == "Table")
        {
            TableComportment(ros);
        }
    }

    private void ClosetComportment()
    {
        GUIManager.ShowMessage("Sexy Costume times", 1.2f);
    }

    private void TableComportment(MonoBehaviour ros)
    {
        GUIManager.ShowMessage("I'll take this toy ... I guess", 1.2f);
        var GMichet = GameObject.Find("Table/GMichet");
        GMichet.renderer.enabled = false;

        CurrentItem = GMichet;
        GUIManager.SetCollectItemTexture(GMichet.GetComponent<SpriteRenderer>().sprite);
    }


}
