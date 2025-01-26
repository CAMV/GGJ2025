using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

        _pendingUpdates.Add(new GameDataChangeStateUpdate(_state.Companies.Values.ToList()));
        SendUpdates();
    }

    private void SendUpdates() {
        GameController.QueueStateUpdates(_pendingUpdates);
        _pendingUpdates.Clear();
    }
}
