using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CollisionTracker))]
public class Button : MonoBehaviour 
{
    public GameObject elevator;
    public ButtonType btype;

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
                    break;

                case ButtonType.ElevatorUp:
                    movement = Vector3.up * 2.0f * Time.deltaTime;
                    elevator.transform.position = elevator.transform.position + movement;
                    break;
            }
        }
	}

    public enum ButtonType
    {
        ElevatorUp,
        ElevatorDown
    }
}
