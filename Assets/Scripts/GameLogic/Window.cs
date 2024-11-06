using System;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _button;

    public event Action ButtonClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    public void Open()
    {
        _windowGroup.alpha = 1f;
        _button.interactable = true;
    }

    public void Close()
    {
        _windowGroup.alpha = 0f;
        _button.interactable = false;
    }

    private void OnButtonClicked()
    {
        ButtonClicked?.Invoke();
    }
}