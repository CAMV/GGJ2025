using UnityEngine;

public class GameEventCard {
    public GameEvent GameEvent;
    public string CompanyId;

    public GameEventCard(GameEvent ge, string cId) {
        GameEvent = ge;
        CompanyId = cId;
    }

    public void ExecuteEvent(GameState state) {
        GameEvent.Execute(state, CompanyId);
    }
}
