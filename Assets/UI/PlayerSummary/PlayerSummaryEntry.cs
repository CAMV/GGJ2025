using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSummaryEntry : MonoBehaviour {
    public TMP_Text PlayerName;
    public TMP_Text PlayerCash;
    public Transform HoldingsParent;
    public GameObject EntryPrefab;

    private Dictionary<string, SingleCompanyHoldingSummary> _holdingDict;

    public void Initialize(PlayerState state) {
        foreach (Transform child in HoldingsParent) {
            Destroy(child.gameObject);
        }
        _holdingDict = new Dictionary<string, SingleCompanyHoldingSummary>();
        foreach (string companyId in state.Stocks.Keys) {
            var entryObj = Instantiate(EntryPrefab, HoldingsParent);
            _holdingDict.Add(companyId, entryObj.GetComponent<SingleCompanyHoldingSummary>());
        }
        UpdateData(state);
    }

    public void UpdateData(PlayerState state) {
        PlayerName.text = state.PlayerName;
        PlayerCash.text = $"{state.Money}$";
        foreach (string companyId in state.Stocks.Keys) {
            _holdingDict[companyId].UpdateData(state);
        }
    }
}
