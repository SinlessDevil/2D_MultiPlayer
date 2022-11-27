using System.Collections;
using Photon.Pun;
using UnityEngine;

namespace Scripts.Player.ShootingSystem{
    public class Bullet : MonoBehaviour{
        [Header("Variabls Bullet")]
        [SerializeField] private float _speed;
        [SerializeField] private float _lifetime;

        private bool _isActive = false;

        private GameObject _gun;
        private GameObject _shotPoint;
        private PhotonView _photonView;

        private void Awake()
        {
            _gun = GameObject.Find("GunPlayer");
            _shotPoint = GameObject.Find("ShotPoint");
            _photonView = GetComponent<PhotonView>();
        }

        private void OnEnable(){
            this.StartCoroutine(LifeTimeBulletCoroutine());
        }
        private void OnDisable(){
            this.StopCoroutine(LifeTimeBulletCoroutine());
        }

        private void FixedUpdate(){
            MoveBullet();
        }

        private void MoveBullet(){
            if (_isActive){
                transform.Translate(Vector2.up * _speed * Time.fixedDeltaTime);
            }
        }

        private IEnumerator LifeTimeBulletCoroutine(){

           this.gameObject.transform.position = _gun.transform.position;
           this.gameObject.transform.rotation = _gun.transform.rotation;

            _isActive = true;
            yield return new WaitForSeconds(_lifetime);
            _isActive = false;
            Deactivate();

            this.transform.position = _shotPoint.transform.position;
            this.transform.rotation = _shotPoint.transform.rotation;
        }
        private void Deactivate(){
            this.gameObject.SetActive(false);
        }
    }
}
