using System;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    [SerializeField] private RocketDetecter[] _rocketDetecters;

    public event Action GameOver;

    private void OnEnable()
    {
        foreach (var rocketDetecter in _rocketDetecters)
            rocketDetecter.Detected += OnTriggerEnterRocket;
    }

    private void OnDisable()
    {
        foreach (var rocketDetecter in _rocketDetecters)
            rocketDetecter.Detected -= OnTriggerEnterRocket;
    }

    public void OnTriggerEnterRocket()
    {
        GameOver?.Invoke();
    }
}