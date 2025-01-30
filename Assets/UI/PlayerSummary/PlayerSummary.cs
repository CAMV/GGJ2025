using System.Collections.Generic;
using UnityEngine;

public class PlayerSummary : MonoBehaviour {
    public PlayerSummaryHeader SummaryHeader;
    public Transform EntriesParent;
    public GameObject EntriesPrefab;

    private bool _initialized = false;
    private Dictionary<string, PlayerSummaryEntry> _playerDict;

    public void Initialize(GameDataChangeStateUpdate update) {
        SummaryHeader.Initialize(update.Companies);
        InitializeEntries(update);
        _initialized = true;
    }

    public void UpdateData(GameDataChangeStateUpdate update) {
        if (!_initialized) {
            Initialize(update);
        } else {
            UpdateEntries(update);
        }
    }

    private void InitializeEntries(GameDataChangeStateUpdate update) {
        _playerDict = new Dictionary<string, PlayerSummaryEntry>();
        foreach (PlayerState player in update.Players) {
            var entryObj = Instantiate(EntriesPrefab, EntriesParent);
            _playerDict.Add(player.PlayerName, entryObj.GetComponent<PlayerSummaryEntry>());
            _playerDict[player.PlayerName].Initialize(player);
        }
        UpdateEntries(update);
    }

    private void UpdateEntries(GameDataChangeStateUpdate update) {
        foreach (PlayerState player in update.Players) {
            _playerDict[player.PlayerName].UpdateData(player);
        }
    }
}
