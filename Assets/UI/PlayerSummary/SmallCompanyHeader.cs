using UnityEngine;
using UnityEngine.UI;

public class SmallCompanyHeader : MonoBehaviour {
    public Image Icon;

    public void Initialize(Company company) {
        Icon.sprite = company.GetLogo();
    }
}
