using UnityEngine;
using Service.Pool;

class Pistol : MonoBehaviour
{    
    [SerializeField]
    private BasePoolSetup _bulletsPoolSetup;
    [SerializeField]
    private float _bulletsLifeTime = 1f;

    private PoolService<Bullet> _bulletsPool;    

    private void Start()
    {
        _bulletsPool = new PoolService<Bullet>(new DefaultPoolEventHandler(), _bulletsPoolSetup);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            MakeBullet();
        }

        for (int i = _bulletsPool.activeObjects.Count-1; i >= 0; i--)
        {
            if (_bulletsPool.activeObjects[i].lifeTime <= 0)
                _bulletsPool.Return(_bulletsPool.activeObjects[i]);
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
