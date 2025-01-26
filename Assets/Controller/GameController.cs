using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameServer GameServer;
    public GameUI UI;

    private Queue<StateUpdateBase> _stateUpdateQueue;

    public static Dictionary<string, Company> ActiveCompanies;

    private bool waitingForPlayerInput = false;

    private void Start() {
        StartGame(4);
    }

    private void Update() {
        if (waitingForPlayerInput && Input.GetKeyDown(KeyCode.Space)) {
            waitingForPlayerInput = false;
            SendCommand(EGameServerCommand.DebugNextTurn);
        }
    }

    public void StartGame(int numPlayers) {
        ActiveCompanies = new Dictionary<string, Company>();
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
                ActiveCompanies.Clear();
                foreach (Company comp in dataChangeUpdate.Companies) {
                    ActiveCompanies.Add(comp.CompanyId, comp);
                }
                UI.UpdateData(dataChangeUpdate);
                break;
            case EStateUpdateIdentifier.PlayerTurn:
                waitingForPlayerInput = true;
                break;
        }
    }

    private void SendCommand(EGameServerCommand command) {
        GameServer.ReceiveCommand(command);
    }
}
