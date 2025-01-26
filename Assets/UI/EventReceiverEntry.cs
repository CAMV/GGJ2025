using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventReceiverEntry", menuName = "Scriptable Objects/EventReceiverEntry")]
public class EventReceiverEntry : ScriptableObject {
    public EGameEventIdentifier eventIdentifier;
    public List<EventReceiverBase> possiblePrefabs;
}
