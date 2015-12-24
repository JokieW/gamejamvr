using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CollisionTracker))]
public class Button : MonoBehaviour 
{
    public GameObject elevator;
    public ButtonType btype;
    bool pressed;

    CollisionTracker tracker;

    void Awake()
    {
        tracker = GetComponent<CollisionTracker>();
        tracker.tagFilter = "Hand";
    }

	void Update ()
    {
        if (tracker.GetFirst() != null)
        {
            Vector3 movement;
            switch (btype)
            {
                case ButtonType.ElevatorDown:
                    if (Limiter.unblocked)
                    {
                        movement = Vector3.down * 2.0f * Time.deltaTime;
                        if ((elevator.transform.position + movement).y >= 0.0)
                        {
                            elevator.transform.position = elevator.transform.position + movement;
                            if (!pressed)
                            {
                                Transform child = transform.GetChild(0);
                                Vector3 t = child.transform.localPosition;
                                child.transform.localPosition = new Vector3(-0.2f, t.y, t.z);
                                pressed = true;
                            }
                        }
                    }
                    break;

                case ButtonType.ElevatorUp:
                    if (Limiter.unblocked)
                    {
                        movement = Vector3.up * 2.0f * Time.deltaTime;
                        elevator.transform.position = elevator.transform.position + movement;
                        if (!pressed)
                        {
                            Transform child = transform.GetChild(0);
                            Vector3 t = child.transform.localPosition;
                            child.transform.localPosition = new Vector3(-0.2f, t.y, t.z);
                            pressed = true;
                        }
                    }
                    break;
            }

            
        }
        else if (pressed)
        {
            Transform child = transform.GetChild(0);
            Vector3 t = child.transform.localPosition;
            switch (btype)
            {
                case ButtonType.ElevatorDown:
                    child.transform.localPosition = new Vector3(0.0f, t.y, t.z);
                    break;

                case ButtonType.ElevatorUp:
                    child.transform.localPosition = new Vector3(0.0f, t.y, t.z);
                    break;
            }
            pressed = false;
        }
	}

    public enum ButtonType
    {
        ElevatorUp,
        ElevatorDown
    }
}
