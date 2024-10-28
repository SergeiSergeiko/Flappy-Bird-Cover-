using UnityEngine;
using UnityEngine.UI;

public class WindowDisabler : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _window;

    private void OnEnable()
    {
        _button.onClick.AddListener(WindowDisable);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(WindowDisable);
    }

    private void WindowDisable()
    {
        _window.gameObject.SetActive(false);
    }
}