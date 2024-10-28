using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSceneChanger : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _nextSceneIndex;

    public event Action<int> Clicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClicked);

    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        Clicked?.Invoke(_nextSceneIndex);
    }
}