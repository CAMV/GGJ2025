using UnityEngine;

public class PlayerTurnStateUpdate : StateUpdateBase {
    public override EStateUpdateIdentifier StateUpdateIdentifier { get { return EStateUpdateIdentifier.PlayerTurn; } }
}
