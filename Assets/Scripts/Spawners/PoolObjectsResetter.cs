using UnityEngine;
using System.Collections.Generic;

public class PoolObjectsResetter : MonoBehaviour
{
    [SerializeField] private List<Resetter> _pools;

    public void Reset()
    {
        foreach (var pool in _pools)
            pool?.Reset();
    }
}