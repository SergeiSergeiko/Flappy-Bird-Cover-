using UnityEngine;
using UnityEngine.UI;

public class WindowEnabler : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _window;
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(WindowEnable);
    }

    private void Start()
    {
        _button.onClick.AddListener(WindowEnable);
    }

    private void WindowEnable()
    {
        _window.gameObject.SetActive(true);
    }
}