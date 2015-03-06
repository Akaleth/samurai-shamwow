using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager {

    public int Phase1DeckSize = 8;
    public int Phase2DeckSize = 16;
    public int Phase3DeckSize = 24;

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

    public void RandomizeDeck(int deck)
    {
        for (int i = 0; i < deck; i++)
        {
            int numAttacks = 2;
            int numDisturbs = 2;
            int numOpps = 1;

            for (int j = 0; j < 3; i++)
            {
                int card = Random.Range(1, 3);
                switch (card)
                {
                    case 1:
                        numAttacks++;
                        break;
                    case 2:
                        numDisturbs++;
                        break;
                    case 3:
                        numOpps++;
                        break;
                    default:
                        break;
                }
            }

            addCards(numAttacks, numDisturbs, numOpps, deck);
        }
    }

    private void addCards(int numAttacks, int numDisturbs, int numOpps, int deck)
    {
        for (int i = 0; i < numAttacks; i++)
        {
            // add attack card to deck
        }
        for (int i = 0; i < numDisturbs; i++)
        {
            // add disturbance card to deck
        }
        for (int i = 0; i < numOpps; i++)
        {
            // add opportunity card to deck
        }

    }
}
