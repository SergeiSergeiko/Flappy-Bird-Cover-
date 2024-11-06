using System;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    public event Action GameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rocket _))
            GameOver?.Invoke();
    }
}