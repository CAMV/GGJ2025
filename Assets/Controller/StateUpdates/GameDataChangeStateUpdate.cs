using System.Collections.Generic;
using UnityEngine;

public class GameDataChangeStateUpdate : StateUpdateBase {
    public override EStateUpdateIdentifier StateUpdateIdentifier { get { return EStateUpdateIdentifier.GameDataChange; } }

    public List<Company> Companies;

    public GameDataChangeStateUpdate(List<Company> comps) {
        Companies = comps;
    }
}
