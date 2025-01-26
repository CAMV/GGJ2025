using UnityEngine;

public enum EStateUpdateIdentifier {
    GameDataChange,
    ProcessUpdates,
    PlayerTurn
}

public abstract class StateUpdateBase {
    public abstract EStateUpdateIdentifier StateUpdateIdentifier { get; }
}
