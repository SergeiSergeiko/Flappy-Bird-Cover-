using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class ExitButton : MonoBehaviour
{
    private Button _button;

    private void OnDisable()
    {
        _button.onClick.RemoveListener(CloseApp);
    }

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(CloseApp);
    }

    private void CloseApp()
    {
        Application.Quit();
    }
}