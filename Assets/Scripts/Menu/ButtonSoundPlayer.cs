using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundPlayer : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private AudioSource _audio;

    private void OnEnable()
    {
        foreach (var button in _buttons)
            button.onClick.AddListener(PlayAudio);
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
            button.onClick.RemoveListener(PlayAudio);
    }

    private void PlayAudio()
    {
        if (_audio.isPlaying)
            _audio.Stop();

        _audio.Play();
    }
}