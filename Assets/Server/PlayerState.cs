using System.Collections.Generic;
using UnityEngine;

public class PlayerState {
    public int Money;
    public string PlayerName;
    public Dictionary<string, int> Stocks;
    public List<PlayerCard> Hand;

    public PlayerState(int initialMoney, string playerName, IEnumerable<Company> initialCompanies) {
        Money = initialMoney;
        PlayerName = playerName;
        Stocks = new Dictionary<string, int>();
        foreach (Company company in initialCompanies) {
            Stocks[company.CompanyId] = 0;
        }

        Hand = new List<PlayerCard>();
    }

    public int GetNetWorth() {
        int res = Money;
        foreach (string companyId in Stocks.Keys) {
            int companyStockPrice = GameController.ActiveCompanies[companyId].StockPrice;
            res += companyStockPrice * Stocks[companyId];
        }
        return res;
    }

    public int GetHoldingsAmount(string companyId) {
        return Stocks[companyId];
    }
}
