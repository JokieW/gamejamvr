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
                    movement = Vector3.down * 2.0f * Time.deltaTime;
                    elevator.transform.position = elevator.transform.position + movement;
                    if (!pressed)
                    {
                        Vector3 t = transform.localPosition;
                        transform.localPosition = new Vector3(-5.0f, t.y, t.z);
                    }
                    break;

                case ButtonType.ElevatorUp:
                    movement = Vector3.up * 2.0f * Time.deltaTime;
                    elevator.transform.position = elevator.transform.position + movement;
                    if (!pressed)
                    {
                        Vector3 t = transform.localPosition;
                        transform.localPosition = new Vector3(-5.0f, t.y, t.z);
                    }
                    break;
            }

            
        }
        else if (pressed)
        {
            Vector3 t = transform.localPosition;
            switch (btype)
            {
                case ButtonType.ElevatorDown:
                    transform.localPosition = new Vector3(-4.81287f, t.y, t.z);
                    break;

                case ButtonType.ElevatorUp:
                    transform.localPosition = new Vector3(-4.81287f, t.y, t.z);
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
