using System;
using UnityEngine; 

public class Bullet : MonoBehaviour
{
    public event Action<Bullet> Collided;

    [field: SerializeField] public int Damage { get; private set; }

    public void OnCollidedHandler()
    {
        Collided?.Invoke(this);
    }
}