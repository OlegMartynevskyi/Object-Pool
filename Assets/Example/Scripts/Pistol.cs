using UnityEngine;
using Service.Pool;

class Pistol : MonoBehaviour
{    
    [SerializeField]
    private BasePoolSetup _bulletsPoolSetup;
    [SerializeField]
    private float _bulletsLifeTime = 1f;

    private PoolService<Bullet> _bulletsPool;
    private PoolActiveObjects<Bullet> _activeObjects;

    private void Start()
    {
        _activeObjects = new PoolActiveObjects<Bullet>();
        _bulletsPool = new PoolService<Bullet>(_activeObjects, _bulletsPoolSetup);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            MakeBullet();
        }

        foreach (var bullet in _activeObjects)
        {
            if (bullet.lifeTime <= 0)
                _bulletsPool.Return(bullet);
        }
    }

    private void MakeBullet()
    {
        Bullet bullet = _bulletsPool.Get();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.lifeTime = _bulletsLifeTime;
        }
    }
}
