using UnityEngine;

public class UIElement : MonoBehaviour
{
    [SerializeField] private UIType _uiType;

    public UIType UIType { get => _uiType; set => _uiType = value; }
}
