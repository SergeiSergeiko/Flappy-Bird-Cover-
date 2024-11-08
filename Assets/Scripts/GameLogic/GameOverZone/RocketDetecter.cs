using System;
using UnityEngine;

public class RocketDetecter : MonoBehaviour
{
    public event Action Detected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rocket _))
            Detected?.Invoke();
    }
}