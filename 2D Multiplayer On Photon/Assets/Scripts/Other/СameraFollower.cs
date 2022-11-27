using UnityEngine;

public class СameraFollower : MonoBehaviour
{
    private PlayerContoroller _targetTransform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothing = 3f;
    private void Start()
    {
        _targetTransform = FindObjectOfType<PlayerContoroller>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var nextPosition = Vector3.Lerp(
            transform.position, 
            _targetTransform.transform.position + _offset, 
            Time.fixedDeltaTime * _smoothing);

        transform.position = nextPosition;
    }
}
