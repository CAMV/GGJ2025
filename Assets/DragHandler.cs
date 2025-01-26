using UnityEngine;
using UnityEngine.EventSystems;

public class WindowDragger : MonoBehaviour
{
    [SerializeField]
    private Transform _windowRoot;
    [SerializeField]
    private float _dragScale;
    public void Move()
    {
        _windowRoot.position += Input.mousePositionDelta * _dragScale; 
    }
}
