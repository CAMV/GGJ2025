using UnityEngine;

public enum EStockDecreaseTier {
    Tier1,
    Tier2,
    Tier3
}

[CreateAssetMenu(fileName = "StockIncreaseGameEvent", menuName = "Scriptable Objects/Game Events/StockDecreaseGameEvent")]
public class StockDecreaseGameEvent : GameEvent {
    public override EGameEventIdentifier EventId { get { return EGameEventIdentifier.StockPriceDecrease; } }
    public override EGameEventTarget EventTargetType { get { return EGameEventTarget.SingleCompany; } }

    public EStockIncreaseTier tier;
    public int value;

    public override void Execute(GameState state, string companyId) {
        Company company = null;
        state.Companies.TryGetValue(companyId, out company);
        if (company != null) {
            company.ChangeStockPrice(-value);
        }
    }
}
