using UnityEngine;

public class Company {
    public string CompanyId;
    public int StockPrice;
    public int StockAmount;
    public int Dividends;
    public int NullifiedTurnsLeft;

    private CompanyData _companyData;
    private int _prevStockPrice;

    public Company(CompanyData data, GameConfig config) {
        CompanyId = data.Id;
        StockPrice = config.initialStockPrice;
        StockAmount = config.initialStockAmount;
        Dividends = config.initialDividends;
        NullifiedTurnsLeft = 0;
        _companyData = data;

        _prevStockPrice = StockPrice;
    }

    public string GetDisplayName() {
        return $"{_companyData.Ticker}/{_companyData.DisplayName}";
    }

    public string GetStockPriceDeltaText() {
        string colorSpec;
        string plusMinus = "+";
        string closingSpec = "</color>";
        
        if (_prevStockPrice < StockPrice) {
            colorSpec = "<color=green>";
        } else if (_prevStockPrice > StockPrice) {
            colorSpec = "<color=red>";
            plusMinus = "-";
        } else {
            colorSpec = "";
            closingSpec = "";
        }
        return $"{StockPrice}${colorSpec}{plusMinus}{GetStockPriceDelta()}{closingSpec}";
    }

    public Sprite GetLogo() {
        return _companyData.Logo;
    }

    public int GetStockPriceDelta() {
        return StockPrice - _prevStockPrice;
    }

    public void ChangeStockPrice(int delta) {
        _prevStockPrice = StockPrice;
        StockPrice += delta;
    }
}
