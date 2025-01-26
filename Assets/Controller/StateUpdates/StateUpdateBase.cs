using UnityEngine;

public enum EStateUpdateIdentifier {
    GameDataChange,
    ProcessUpdates
}

public abstract class StateUpdateBase {
    public abstract EStateUpdateIdentifier StateUpdateIdentifier { get; }
}
