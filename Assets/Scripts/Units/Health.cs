using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private readonly int _minValue = 0;

    public event Action Dies;
    public event Action<int> Changed;

    [field: SerializeField] public int MaxValue;
    public int Value { get; private set; }

    private void OnValidate()
    {
        if (MaxValue <= _minValue)
            MaxValue = _minValue + 1;
    }

    private void Start()
    {
        Set(MaxValue);
    }

    public void TakeDamage(int value)
    {
        int damage = Value - value;

        Set(damage);
    }

    private void Set(int value)
    {
        Value = Mathf.Clamp(value, _minValue, MaxValue);

        if (Value <= 0)
            Dies?.Invoke();

        Changed?.Invoke(Value);
    }
}