using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShareValueIncreaseEventReceiver : EventReceiverBase {
    public TMP_Text StockName;
    public Image StockLogo;
    public TMP_Text ValueChangeText;
    public Image EventImage;

    public List<Sprite> possibleImages;

    public override void UpdateFromCard(GameEventCard card) {
        var company = GameController.ActiveCompanies[card.CompanyId];
        StockName.text = company.GetDisplayName();
        StockLogo.sprite = company.GetLogo();
        ValueChangeText.text = company.GetStockPriceDeltaText();
        EventImage.sprite = possibleImages[Random.Range(0, possibleImages.Count)];
    }
}
