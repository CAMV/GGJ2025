using UnityEngine;

public class Company {
    public string CompanyId;
    public int StockPrice;
    public int StockAmount;
    public int Dividends;
    public int NullifiedTurnsLeft;

    private CompanyData _companyData;

    public Company(CompanyData data, GameConfig config) {
        CompanyId = data.Id;
        StockPrice = config.initialStockPrice;
        StockAmount = config.initialStockAmount;
        Dividends = config.initialDividends;
        NullifiedTurnsLeft = 0;
        _companyData = data;
    }

    public string GetDisplayName() {
        return $"{_companyData.Ticker}/{_companyData.DisplayName}";
    }

    public Sprite GetLogo() {
        return _companyData.Logo;
    }
}
