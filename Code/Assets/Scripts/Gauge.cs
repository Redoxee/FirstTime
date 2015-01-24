using UnityEngine;
using System.Collections;

public class Gauge : MonoBehaviour {

    [SerializeField]
    private GameObject DisplayedGauge;


    public float CurrentProgression = 0.0f;

    private Vector3 BasePosition;
    private float BaseHeigh;

	// Use this for initialization
	void Start () {
        SetProression(0.0f);

        BasePosition = DisplayedGauge.transform.localPosition;
        BaseHeigh = DisplayedGauge.GetComponentInChildren<SpriteRenderer>().sprite.bounds.size.y;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetProression(float prog)
    {
        CurrentProgression = prog;
        Vector3 scale = DisplayedGauge.transform.localScale;
        scale.y = prog;
        DisplayedGauge.transform.localScale = scale;
        DisplayedGauge.transform.localPosition = BasePosition - new Vector3(0, 0.5f, 0) * (1 - prog) * BaseHeigh;
    }
}
