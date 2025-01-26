using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {
    public int MarketWatchCompanyCount = 9;
    public GameObject SingleCompanyMarketWatchPrefab;
    public GameObject MarketSummaryParent;

    private List<CompanyMarketWatchSummary> marketWatchSummaries;

    private void Awake() {
        InitializeMarketWatch();
    }

    public void UpdateData(GameDataChangeStateUpdate update) {
        UpdateMarketWatch(update);
    }

    public void UpdateMarketWatch(GameDataChangeStateUpdate update) {
        for (int i=0; i < MarketWatchCompanyCount; ++i) {
            if (i < update.Companies.Count) {
                marketWatchSummaries[i].SetData(update.Companies[i]);
                marketWatchSummaries[i].gameObject.SetActive(true);
            } else {
                marketWatchSummaries[i].gameObject.SetActive(false);
            }
        }
    }

    private void InitializeMarketWatch() {
        marketWatchSummaries = new List<CompanyMarketWatchSummary>();
        for (int i=0; i < MarketWatchCompanyCount; ++i) {
            var marketWatchObject = Instantiate(SingleCompanyMarketWatchPrefab, MarketSummaryParent.transform);
            marketWatchObject.SetActive(false);
            marketWatchSummaries.Add(marketWatchObject.GetComponent<CompanyMarketWatchSummary>());
        }
    }
}
