using System;
using System.Collections;
using UnityEngine;

public class ScenesTransition : MonoBehaviour
{
    private readonly int AnimationFadeIn = Animator.StringToHash(nameof(FadeIn));

    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private Animator _animator;

    public event Action EndFadeIn;

    private Coroutine _timerEndFadeIn;

    private void OnDisable()
    {
        _sceneChanger.Changing -= FadeIn;
    }

    private void Start()
    {
        _sceneChanger.Changing += FadeIn;
    }

    private void FadeIn()
    {
        _animator.gameObject.SetActive(true);
        _animator.Play(AnimationFadeIn);

        StartTimerEndFadeIn();
    }

    private IEnumerator TimerEndFadeIn()
    {
        float passedTime = 0f;
        float endTime = 3f;

        while (passedTime < endTime)
        {
            passedTime += Time.deltaTime;

            yield return null;
        }

        EndFadeIn?.Invoke();
    }

    private void StartTimerEndFadeIn()
    {
        _timerEndFadeIn ??= StartCoroutine(TimerEndFadeIn());
    }
}