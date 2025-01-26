using System.Collections.Generic;
using UnityEngine;

public class GameState {
    public Dictionary<string, Company> Companies;
    public Dictionary<int, PlayerState> Players;
    public Stack<GameEventCard> EventDeck;
    public Stack<PlayerCard> StockDeck;

    private GameConfig _config;
    private int _numPlayers;

    public GameState(GameConfig config) {
        Companies = new Dictionary<string, Company>();
        _config = config;
        foreach (CompanyData company in config.companies) {
            Companies.Add(company.Id, new Company(company, config));
        }
    }

    public void InitializeState(int numPlayers) {
        GenerateEventCards();
        InitializePlayers(numPlayers);
        InitializeStockDeck();
        DistributeStockDeck();
    }

    private void GenerateEventCards() {
        List<GameEventCard> possibleEventCards = new List<GameEventCard>();
        EventDeck = new Stack<GameEventCard>();

        foreach (GameEvent gameEvent in _config.possibleEvents) {
            switch (gameEvent.EventTargetType) {
                case EGameEventTarget.SingleCompany:
                    foreach (CompanyData data in _config.companies) {
                        possibleEventCards.Add(new GameEventCard(gameEvent, data.Id));
                    }
                    break;
            }
        }

        for (int i = 0; i < _config.handSize * _config.eventsPerTurn; ++i) {
            EventDeck.Push(possibleEventCards[Random.Range(0, possibleEventCards.Count)]);
        }
    }

    private void InitializePlayers(int numPlayers) {
        _numPlayers = numPlayers;
        Players = new Dictionary<int, PlayerState>();
        for (int i=0; i < numPlayers; ++i) {
            Players.Add(i + 1, new PlayerState(_config.initialPlayerMoney));
        }
    }

    private void InitializeStockDeck() {
        var cards = new List<PlayerCard>();
        foreach (Company company in Companies.Values) {
            for (int i=0; i < company.StockAmount; ++i) {
                cards.Add(new PlayerCard(company.CompanyId));
            }
        }
        ShuffleCards(cards);
        StockDeck = new Stack<PlayerCard>(cards);
    }

    private void DistributeStockDeck() {
        for (int i=0; i < _numPlayers ; ++i) {
            for (int j = 0; j < _config.handSize; ++j) {
                Players[i + 1].Hand.Add(StockDeck.Pop());
            }
        }
    }

    private void ShuffleCards(List<PlayerCard> cards) {
        var count = cards.Count;
        var last = count - 1;
        for (int i=0; i<last; ++i) {
            var r = Random.Range(i, count);
            var tmp = cards[i];
            cards[i] = cards[r];
            cards[r] = tmp;
        }
    }
}
