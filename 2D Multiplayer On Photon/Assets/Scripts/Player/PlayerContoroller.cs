using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerContoroller : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _moveVelocity;

    private Rigidbody2D _rb;
    private TMP_Text _nameTextPlayer;
    private PhotonView _photonView;

    private void Start(){
        _rb = GetComponent<Rigidbody2D>();
        _nameTextPlayer = GetComponentInChildren<TMP_Text>();
        _photonView = GetComponent<PhotonView>();
        RPC_LoadNickName();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Update(){
        if (!_photonView.IsMine)
            return;

        Contorller();
    }

    private void Contorller(){
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveVelocity = moveInput.normalized * _speed;
    }
    private void Move(){
        _rb.MovePosition(_rb.position + _moveVelocity * Time.fixedDeltaTime);
    }

    private void RPC_LoadNickName()
    {
        _photonView.RPC("NickName", RpcTarget.AllBuffered, PhotonNetwork.NickName);
    }
    [PunRPC] private void NickName(string nickName)
    {
        _nameTextPlayer.text = nickName;
    }
}
