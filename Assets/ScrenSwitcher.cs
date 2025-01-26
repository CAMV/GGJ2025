using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.WebRequestMethods;
public class ScrenSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject _newsScreen;
    [SerializeField] 
    private GameObject _marketScreen;
    [SerializeField]
    private TMP_Text _urlText;

    public void SwitchToMarket()
    {
        _urlText.text = "http://hodlreport.com/home/markets";
        _newsScreen.SetActive(false);
        _marketScreen.SetActive(true);
    }

    public void SwitchToNews()
    {
        _urlText.text = "http://hodlreport.com/home/news";
        _marketScreen.SetActive(false);
        _newsScreen.SetActive(true);
    }
}
