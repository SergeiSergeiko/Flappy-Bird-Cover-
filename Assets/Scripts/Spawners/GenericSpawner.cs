using UnityEngine;

public class GenericSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected GenericPoolObjects<T> Pool;

    protected virtual void Spawn(Vector3 position)
    {
        T obj = GetObject();
        Subscribe(obj);
        obj.transform.position = position;
    }

    protected virtual T GetObject()
    {
        return Pool.Get();
    }

    protected virtual void Subscribe(T Obj) { }
}