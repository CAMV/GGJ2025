using UnityEngine;

[CreateAssetMenu(fileName = "GameEventData", menuName = "Scriptable Objects/GameEvent")]
public abstract class GameEvent : ScriptableObject {
    public abstract EGameEventIdentifier EventId { get; }
    public abstract EGameEventTarget EventTargetType { get; }

    public abstract void Execute(GameState state, string companyId);
}
