using System.Collections.Generic;
using UnityEngine;

public class GameDataChangeStateUpdate : StateUpdateBase {
    public override EStateUpdateIdentifier StateUpdateIdentifier { get { return EStateUpdateIdentifier.GameDataChange; } }

    public List<Company> Companies;
    public List<GameEventCard> EventsExecuted;
    public List<PlayerState> Players;

    public GameDataChangeStateUpdate(List<Company> comps, List<PlayerState> players) {
        Companies = comps;
        Players = players;
        EventsExecuted = new List<GameEventCard>();
    }
}
