using System;
using UnityEngine; 

public class Bullet : MonoBehaviour
{
    public event Action<Bullet> Removing;

    [field: SerializeField] public int Damage { get; private set; }

    public void Remove()
    {
        Removing?.Invoke(this);
    }
}