using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private ButtonSceneChanger _button;
    [SerializeField] private ScenesTransition _sceneTransition;

    public event Action Changing;

    private int _sceneIndex;

    private void OnEnable()
    {
        _button.Clicked += OnClickedButtonSceneChanger;
        _sceneTransition.EndFadeIn += LoadScene;
    }

    private void OnDisable()
    {
        _button.Clicked -= OnClickedButtonSceneChanger;
        _sceneTransition.EndFadeIn -= LoadScene;
    }

    private void OnClickedButtonSceneChanger(int index)
    {
        _sceneIndex = index;
        Changing?.Invoke();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}