using UnityEngine;

class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;

    public float lifeTime;    

    private void Update()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime);
        if (lifeTime > 0)
            lifeTime -= Time.deltaTime;
    }
}
