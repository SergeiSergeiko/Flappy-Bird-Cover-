using System.Collections;
using UnityEngine;

public class SmallEnemySpawner : GenericSpawner<SmallEnemy>
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delay;

    [SerializeField] private BulletSpawner _bulletSpawner;

    private Coroutine _spawning;
    private bool _isSpawn = true;
    private int _counter = 0;

    private void Start()
    {
        _spawning ??= StartCoroutine(Spawning());
    }

    public void StopSpawning()
    {
        if (_spawning != null)
            StopCoroutine(_spawning);
    }

    protected override void Subscribe(SmallEnemy enemy)
    {
        enemy.Died += OnEnemyDiedHandler;
        enemy.Attacked += _bulletSpawner.OnOwnerAttackedHandler;
    }

    private void OnEnemyDiedHandler(Enemy enemy)
    {
        enemy.Died -= OnEnemyDiedHandler;

        if (enemy is SmallEnemy smallEnemy)
        {
            smallEnemy.Attacked -= _bulletSpawner.OnOwnerAttackedHandler;
            Pool.Release(smallEnemy);
        }
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_isSpawn)
        {
            Vector3 position = GetSpawnPosition();
            Spawn(position);

            yield return wait;
        }
    }

    private Vector3 GetSpawnPosition()
    {
        return _spawnPoints[_counter++ % _spawnPoints.Length].position;
    }
}