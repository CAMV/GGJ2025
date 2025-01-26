using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Scriptable Objects/GameConfig")]
public class GameConfig : ScriptableObject {
    public int handSize = 6;
    public int eventsPerTurn = 3;
    public int initialStockPrice = 12;
    public int initialStockAmount = 50;
    public int initialPlayerMoney = 100;
    public List<CompanyData> companies;
    public List<GameEvent> possibleEvents;
}
