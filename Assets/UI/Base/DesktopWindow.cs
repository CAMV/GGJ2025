using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public struct DesktopWindowData {
    public Sprite Icon;
    public string HeaderText;
    public Action OnClose;
    public GameObject Content;
}

public class DesktopWindow : MonoBehaviour {
    [Header("Header")]
    public RectTransform HeaderTransform;
    public Image HeaderIcon;
    public TMP_Text HeaderText;

    [Header("Callbacks")]
    public Button CloseButton;

    [Header("Content")]
    public Transform ContentParent;

    [Header("Debug")]
    public bool UseDebug = false;
    public GameObject DebugContent;
    public Sprite DebugIcon;
    public string DebugTitle;

    private void Start() {
        if (UseDebug) {
            DesktopWindowData data;
            data.Content = DebugContent;
            data.Icon = DebugIcon;
            data.OnClose = null;
            data.HeaderText = DebugTitle;

            Initialize(data);
        }
    }

    public void Initialize(DesktopWindowData data) {
        CloseButton.onClick.RemoveAllListeners();
        foreach(Transform child in ContentParent) {
            Destroy(child.gameObject);
        }

        HeaderIcon.sprite = data.Icon;
        HeaderText.text = data.HeaderText;
        if (data.OnClose != null) {
            CloseButton.onClick.AddListener(new UnityEngine.Events.UnityAction(data.OnClose));
        }
        Transform contentObj = Instantiate(data.Content.transform, ContentParent);
        RectTransform rt = contentObj.GetComponent<RectTransform>();

        HeaderTransform.sizeDelta = new Vector2(rt.sizeDelta.x, HeaderTransform.sizeDelta.y);
    }
}
