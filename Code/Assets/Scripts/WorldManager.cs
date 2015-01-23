using UnityEngine;
using System.Collections;

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
        else if (Input.GetMouseButtonDown(1))
        {
            GUIManager.ShowMessage("Hello", 1);
        }
        
	}
}
