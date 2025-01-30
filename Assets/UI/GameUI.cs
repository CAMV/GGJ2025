using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {
    [Header("Player Summary")]
    public PlayerSummary PlayerSummary;

    [Header ("Market Watch")]
    public int MarketWatchCompanyCount = 9;
    public GameObject SingleCompanyMarketWatchPrefab;
    public GameObject MarketSummaryParent;

    [Header ("Events")]
    public GameObject EventNewsParent;
    public List<EventReceiverEntry> eventReceivers;

    private List<CompanyMarketWatchSummary> marketWatchSummaries;
    private Dictionary<EGameEventIdentifier, EventReceiverEntry> eventReceiverEntryDict;

    private void Awake() {
        InitializeMarketWatch();
        eventReceiverEntryDict = new Dictionary<EGameEventIdentifier, EventReceiverEntry>();
        foreach (EventReceiverEntry entry in eventReceivers) {
            eventReceiverEntryDict[entry.eventIdentifier] = entry;
        }
    }

    public void UpdateData(GameDataChangeStateUpdate update) {
        UpdateMarketWatch(update);
        UpdateEventNews(update);
        PlayerSummary.UpdateData(update);
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

    public void UpdateEventNews(GameDataChangeStateUpdate update) {
        foreach (Transform child in EventNewsParent.transform) {
            Destroy(child.gameObject);
        }
        foreach (GameEventCard card in update.EventsExecuted) {
            var prefabList = eventReceiverEntryDict[card.GameEvent.EventId].possiblePrefabs;
            var prefab = Instantiate(prefabList[Random.Range(0, prefabList.Count)], EventNewsParent.transform);
            prefab.GetComponent<EventReceiverBase>().UpdateFromCard(card);
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
