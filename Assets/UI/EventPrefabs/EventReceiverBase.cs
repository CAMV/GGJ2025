using UnityEngine;

public abstract class EventReceiverBase : MonoBehaviour {
    public abstract void UpdateFromCard(GameEventCard card);
}
