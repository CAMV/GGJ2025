using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompanyMarketWatchSummary : MonoBehaviour {
    [SerializeField]
    private TMP_Text _companyTitle;
    [SerializeField]
    private Image _companyLogo;
    [SerializeField]
    private TMP_Text _shareCountText;
    [SerializeField]
    private TMP_Text _shareValueText;
    [SerializeField]
    private TMP_Text _profitProjectionText;
    [SerializeField]
    private TMP_Text _quartersProfitText;

    public void SetData(Company company) {
        _companyLogo.sprite = company.GetLogo();
        _companyTitle.text = company.GetDisplayName();
        _shareCountText.text = $"{company.StockAmount} +0";
        _shareValueText.text = $"{company.StockPrice} +0";
        _profitProjectionText.text = $"{company.Dividends} +0";
        _quartersProfitText.text = $"{company.Dividends} +0";
    }
}
