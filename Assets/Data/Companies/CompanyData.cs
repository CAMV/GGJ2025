using UnityEngine;

[CreateAssetMenu(fileName = "CompanyData", menuName = "Scriptable Objects/CompanyData")]
public class CompanyData : ScriptableObject {
    [SerializeField]
    private string _id;
    public string Id { get { return _id; } }
    [SerializeField]
    private string _displayName;
}
