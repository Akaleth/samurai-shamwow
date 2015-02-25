using UnityEngine;
using System.Collections.Generic;

public class Event {

    public enum EventType { Attack, Disturbance, Opportunity }
    public EventType MyType;
    public delegate void ActivateEvent();
    public ActivateEvent Activation;

    public Event(EventType type, ActivateEvent activation)
    {
        MyType = type;
        Activation = activation;
    }

    public void Activate()
    {
        Activation();
    }

}
