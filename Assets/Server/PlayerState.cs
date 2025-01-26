using System.Collections.Generic;
using UnityEngine;

public class PlayerState {
    public int Money;
    public Dictionary<string, int> Stocks;
    public List<PlayerCard> Hand;

    public PlayerState(int initialMoney) {
        Money = initialMoney;
        Stocks = new Dictionary<string, int>();
        Hand = new List<PlayerCard>();
    }
}
