using UnityEngine;

public class UIManager : MonoBehaviour
{
    private UIElement[] _uiElements;

    public void ActivateUIElement(UIType uiType)
    {
        foreach (var uiElement in _uiElements)
        {
            if (uiElement.UIType == uiType)
            {
                uiElement.gameObject.SetActive(true);
            }
            else
            {
                uiElement.gameObject.SetActive(false);
            }
        }
    }

    public void DeactivateAllUIElements()
    {
        foreach (var uiElement in _uiElements)
        {
            if (uiElement.gameObject.activeSelf)
            {
                uiElement.gameObject.SetActive(false);
            }
        }
    }

    public void InitializeUIElements()
    {
        _uiElements = new UIElement[transform.childCount];
        _uiElements = GetComponentsInChildren<UIElement>();
    }
}
