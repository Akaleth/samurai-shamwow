using UnityEngine;
using System.Collections.Generic;

public class Event {

    public enum EventType { Attack, Disturbance, Opportunity }
    public EventType MyType;
    public delegate void ActivateEvent();
    public ActivateEvent Activation;

    public enum EventState { Inactive, InProgress, Succeeded, Failed }
    public EventState State;

    public Event(EventType type, ActivateEvent activation)
    {
        MyType = type;
        Activation = activation;
        State = EventState.Inactive;
    }

    public void Activate()
    {
        Activation();
    }

}
