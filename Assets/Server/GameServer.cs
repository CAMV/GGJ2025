using System.Collections.Generic;
using UnityEngine;

public class GameServer : MonoBehaviour {
    [SerializeField]
    private GameConfig _config;

    private GameState _state;

    
    private void Awake() {
        _state = new GameState(_config);
        _state.InitializeState(4);
        Debug.Log("Initialized");
    }
}
