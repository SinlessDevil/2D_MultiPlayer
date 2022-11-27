using UnityEngine;

namespace Scripts.Player.ShootingSystem
{
    public class Gun : MonoBehaviour
    {
        [Header("Offset for Mouse")]
        [SerializeField] private float _offset = -90f;
        [Space]
        [Header("Prefab & ShotPoint")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shotPoint;
        [Space]
        [Header("Delay between shots")]
        [SerializeField] private float _startTimeBtwShots = 0.2f;
        [Space]
        [Header("Variabls for PoolMono")]
        [SerializeField] private int _poolCount = 10;
        [SerializeField] private bool _autoExpand = true;

        private float _timeBtwShots;
        private PoolMono<Bullet> _pool;

        private void Start(){
            //Create PoolMono
            this._pool = new PoolMono<Bullet>(this._bulletPrefab, this._poolCount, this._shotPoint);
            this._pool.autoExpand = this._autoExpand;
        }

        private void Update(){
            RotateGunRelativeToMouse();
            Shoot();
        }

        private void RotateGunRelativeToMouse()
        {
            Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + _offset);
        }

        private void Shoot()
        {
            if(_timeBtwShots <= 0){
                if (Input.GetMouseButtonDown(0)){
                    CreateBullet();
                    _timeBtwShots = _startTimeBtwShots;
                }
            }else{
                _timeBtwShots -= Time.deltaTime;
            }
        }
        private void CreateBullet()
        {
            var cube = this._pool.GetFreeElement();
        }
    }
}