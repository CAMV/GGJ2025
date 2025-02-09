using UnityEngine;
using UnityEngine.EventSystems;

public class WindowDragger : MonoBehaviour, IDragHandler, IPointerDownHandler {

    public RectTransform TargetTransform;
    private Canvas _canvas;

    private void Awake() {
        _canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData) {
        TargetTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData) {
        TargetTransform.SetAsLastSibling();
    }
}
