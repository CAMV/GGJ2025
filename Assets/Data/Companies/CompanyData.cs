using UnityEngine;

[CreateAssetMenu(fileName = "CompanyData", menuName = "Scriptable Objects/CompanyData")]
public class CompanyData : ScriptableObject {
    [SerializeField]
    private string _id;
    public string Id { get { return _id; } }
    [SerializeField]
    private string _displayName;
    [SerializeField]
    private string _ticker;
    public string Ticker { get { return _ticker; } }
    public string DisplayName { get { return _displayName; } }
    [SerializeField]
    private Sprite _logo;
    public Sprite Logo { get { return _logo; } }
}
