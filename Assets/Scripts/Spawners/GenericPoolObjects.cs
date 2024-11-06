using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GenericPoolObjects<T> : Resetter where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _capacity;
    [SerializeField] private int _maxCapacity;

    protected List<T> Objects = new();

    private ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            Create, OnGet, OnRelease, OnDestroyObj,
            collectionCheck: true,
            defaultCapacity: _capacity,
            maxSize: _maxCapacity
        );
    }

    public T Get()
    {
        return _pool.Get();
    }

    public void Release(T obj)
    {
        _pool.Release(obj);
    }

    private T Create()
    {
        T obj = Instantiate(_prefab);
        Objects.Add(obj);

        return obj;
    }

    private void OnGet(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void OnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnDestroyObj(T obj)
    {
        Destroy(obj);
    }
}