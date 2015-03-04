using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager {

    public int Phase1DeckSize = 6;
    public int Phase1DeckSize = 12;
    public int Phase1DeckSize = 18;

    private Stack<Event> _eventDeck1;
    private Stack<Event> _eventDeck2;
    private Stack<Event> _eventDeck3;

    /// <summary>
    /// The game has 3 phases.  Phase# = cap on concurrent events.
    /// </summary>
    private int _phase
    {
        get
        {
            return (_eventDeck1.Count == 0 ? 1 : 0) + (_eventDeck2.Count == 0 ? 1 : 0) + (_eventDeck3.Count == 0 ? 1 : 0);
        }
    }

    public EventManager()
    {
        InitializeDecks();
    }

    /// <summary>
    /// Populates each deck with Events.
    /// </summary>
    private void InitializeDecks()
    {
        _eventDeck1 = new Stack<Event>();
        _eventDeck2 = new Stack<Event>();
        _eventDeck3 = new Stack<Event>();


    }

    // Here, we'll hold all of the activation methods for events

    public Event.ActivateEvent Attack_SpawnBandits(int difficulty)
    {
        return null;
    }

    public Event.ActivateEvent Attack_SpawnNinjas(int difficulty)
    {
        return null;
    }

    public Event.ActivateEvent Attack_SpawnEnemySamurai(int difficulty)
    {
        return null;
    }

    public Event.ActivateEvent Disturbance_SpawnDrunkard(int difficulty)
    {
        return null;
    }

    public Event.ActivateEvent Disturbance_SpawnThief(int difficulty)
    {
        return null;
    }

    public Event.ActivateEvent Opportunity_SpawnAssassin(int difficulty)
    {
        return null;
    }

    public Event.ActivateEvent Opportunity_SpawnHealer(int difficulty)
    {
        return null;
    }

    public Event.ActivateEvent Opportunity_SpawnStoryTeller(int difficulty)
    {
        return null;
    }
}
