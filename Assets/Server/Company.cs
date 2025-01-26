using UnityEngine;

public class Company {
    public string CompanyId;
    public int StockPrice;
    public int StockAmount;
    public int NullifiedTurnsLeft;

    public Company(string id, int initialPrice, int initialAmount) {
        CompanyId = id;
        StockPrice = initialPrice;
        StockAmount = initialAmount;
        NullifiedTurnsLeft = 0;
    }

    public int GetDividends(int amountOwned) {
        return amountOwned * (StockPrice / StockAmount);
    }
}
