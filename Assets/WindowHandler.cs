using System;
using UnityEngine;
using DG.Tweening;

public class WindowHandler : MonoBehaviour
{
    [Serializable]
    public struct app
    {
        public bool isOpen;
        public GameObject windowRoot;
        public GameObject icon;
        public Vector3 lastOpenPosition;
    }

    [SerializeField]
    private app[] _apps;

    public void CloseApp(int index)
    {
        if (index < 0 || index >= _apps.Length)
            return;

        if (!_apps[index].isOpen)
            return;

        var icon = _apps[index].icon;
        var root = _apps[index].windowRoot;

        _apps[index].lastOpenPosition = root.transform.position;
        _apps[index].isOpen = false;
        _apps[index].windowRoot.transform.DOMove(icon.transform.position, .33f).SetEase(Ease.InBack);
        _apps[index].windowRoot.transform.DOScale(Vector3.zero, .33f).SetEase(Ease.InBack);
    }

    public void OpenApp(int index)
    {
        if (index < 0 || index >= _apps.Length)
            return;

        if (_apps[index].isOpen)
            return;

        var lastOpenPos = _apps[index].lastOpenPosition;
        var root = _apps[index].windowRoot;

        _apps[index].isOpen = true;
        _apps[index].windowRoot.transform.DOMove(lastOpenPos, .33f).SetEase(Ease.OutBack);
        _apps[index].windowRoot.transform.DOScale(Vector3.one, .33f).SetEase(Ease.OutBack);
    }

    public void SetAppOnTop(int index)
    {
        if (index < 0 || index >= _apps.Length)
            return;

        _apps[index].windowRoot.transform.SetAsLastSibling();
    }

}
