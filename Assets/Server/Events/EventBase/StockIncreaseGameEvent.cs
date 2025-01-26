using UnityEngine;

public enum EStockIncreaseTier {
    Tier1,
    Tier2,
    Tier3
}

[CreateAssetMenu(fileName = "StockIncreaseGameEvent", menuName = "Scriptable Objects/Game Events/StockIncreaseGameEvent")]
public class StockIncreaseGameEvent : GameEvent {
    public override EGameEventIdentifier EventId { get { return EGameEventIdentifier.StockPriceIncrease; } }
    public override EGameEventTarget EventTargetType { get { return EGameEventTarget.SingleCompany; } }

    public EStockIncreaseTier tier;
    public int value;

    public override void Execute(GameState state, string companyId) {
        Company company = null;
        state.Companies.TryGetValue(companyId, out company);
        if (company != null) {
            company.StockPrice += value;
        }
    }
}
