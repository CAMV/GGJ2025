using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameServer GameServer;
    public GameUI UI;

    private Queue<StateUpdateBase> _stateUpdateQueue;

    private void Start() {
        StartGame(4);
    }

    public void StartGame(int numPlayers) {
        _stateUpdateQueue = new Queue<StateUpdateBase>();
        GameServer.StartGame(numPlayers);
    }

    public void QueueStateUpdates(List<StateUpdateBase> stateUpdates) {
        foreach (StateUpdateBase update in stateUpdates) {
            _stateUpdateQueue.Enqueue(update);
        }
        ProcessStateUpdates();
    }

    public void ProcessStateUpdates() {
        while (_stateUpdateQueue.Count > 0) {
            ProcessSingleUpdate(_stateUpdateQueue.Dequeue());
        }
    }

    private void ProcessSingleUpdate(StateUpdateBase update) {
        switch(update.StateUpdateIdentifier) {
            case EStateUpdateIdentifier.GameDataChange:
                var dataChangeUpdate = (GameDataChangeStateUpdate) update;
                UI.UpdateData(dataChangeUpdate);
                break;
        }
    }
}
