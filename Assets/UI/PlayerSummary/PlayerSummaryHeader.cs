using System.Collections.Generic;
using UnityEngine;

public class PlayerSummaryHeader : MonoBehaviour {
    public Transform CompaniesParent;
    public GameObject CompanyHeaderPrefab;

    public void Initialize(List<Company> companies) {
        foreach (Transform child in CompaniesParent) {
            Destroy(child.gameObject);
        }
        foreach (Company company in companies) {
            var compObj = Instantiate(CompanyHeaderPrefab, CompaniesParent);
            compObj.GetComponent<SmallCompanyHeader>().Initialize(company);
        }
    }
}
