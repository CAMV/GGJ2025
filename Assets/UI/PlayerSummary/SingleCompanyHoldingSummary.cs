using TMPro;
using UnityEngine;

public class SingleCompanyHoldingSummary : MonoBehaviour {
    public TMP_Text HoldingsAmount;

    private string _companyId;

    public void Initialize(string companyId) {
        _companyId = companyId;
    }

    public void UpdateData(PlayerState state) {
        HoldingsAmount.text = $"{state.GetHoldingsAmount(_companyId)}";
    }
}
