using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EGameServerCommand {
    DebugNextTurn
}

public class GameServer : MonoBehaviour {
    public GameController GameController;
    [SerializeField]
    private GameConfig _config;
    private GameState _state;

    private List<StateUpdateBase> _pendingUpdates;

    public void StartGame(int numPlayers) {
        _pendingUpdates = new List<StateUpdateBase>();
        _state = new GameState(_config);
        _state.InitializeState(numPlayers);

        _pendingUpdates.Add(CreateGameDataChangeUpdate());
        _pendingUpdates.Add(new PlayerTurnStateUpdate());
        SendUpdates();
    }

    public void ReceiveCommand(EGameServerCommand command) {
        switch (command) {
            case EGameServerCommand.DebugNextTurn:
                DebugNextTurn();
                break;
        }
    }

    private void DebugNextTurn() {
        List<GameEventCard> events = _state.GetEvents(_config.eventsPerTurn);
        foreach (GameEventCard card in events) {
            card.ExecuteEvent(_state);
        }

        var dataUpdate = CreateGameDataChangeUpdate();
        dataUpdate.EventsExecuted = events;
        _pendingUpdates.Add(dataUpdate);
        _pendingUpdates.Add(new PlayerTurnStateUpdate());
        SendUpdates();
    }

    private void SendUpdates() {
        GameController.QueueStateUpdates(_pendingUpdates);
        _pendingUpdates.Clear();
    }

    private GameDataChangeStateUpdate CreateGameDataChangeUpdate() {
        return new GameDataChangeStateUpdate(_state.Companies.Values.ToList(), _state.Players.Values.ToList());
    }
}
