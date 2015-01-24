using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

    public TextMesh DisplayText;

    [SerializeField]
    private Gauge P1Gauge;

    private Vector3 StartTextPosition = new Vector3(0, -5, -9);
    private Vector3 ShowMessagePosition = new Vector3(0, -2, -9);


    private float TransitionTime = 0.5f;
    private float MessageDisplayDuration = 0f;
    private float TimeStamp;

    private string MessageState = "none";

	// Use this for initialization
	void Start () {
        DisplayText.transform.position = StartTextPosition;
	}
	
	// Update is called once per frame
	void Update () {
        if (MessageState == "TransitionIn")
        {
            float progression = (Time.time - TimeStamp) / TransitionTime;
            if (progression >= 1f)
            {
                TimeStamp = Time.time;
                MessageState = "Showing";
                progression = 1f;
            }
            Vector3 msgPosition = StartTextPosition + (ShowMessagePosition - StartTextPosition) * progression;
            DisplayText.transform.position = msgPosition;
        }
        else if (MessageState == "Showing")
        {
            if (Time.time - TimeStamp > MessageDisplayDuration)
            {
                MessageState = "TransitionOut";
                TimeStamp = Time.time;
            }
        }
        else if (MessageState == "TransitionOut")
        {
            float progression = (Time.time - TimeStamp) / TransitionTime;
            if (progression >= 1f)
            {
                TimeStamp = Time.time;
                MessageState = "Hided";
                progression = 1f;
            }
            Vector3 msgPosition = StartTextPosition + (ShowMessagePosition - StartTextPosition) * (1f - progression);
            DisplayText.transform.position = msgPosition;
        }
	}


    public void ShowMessage(string message, float duration)
    {
        DisplayText.text = message;
        TimeStamp = Time.time;
        MessageState = "TransitionIn";
        MessageDisplayDuration = duration;
    }

    [SerializeField]
    private GameObject SelectedObjectGizmo;

    public void SetCollectItemTexture(Sprite sprite)
    {
        SpriteRenderer sRenderer = SelectedObjectGizmo.GetComponentsInChildren<SpriteRenderer>()[1];
        sRenderer.sprite = sprite;
    }

    public float GetGaugeLevel(string player)
    {
        return P1Gauge.CurrentProgression;
    }
    public void SetGaugeLevel(string player, float level)
    {
        if (player == "P1")
        {
            P1Gauge.SetProression(level);
        }
    }
}
