using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private float _horizontalValue;
    private float _xVelocity;
    private bool _isFacingRight;

    private void Start()
    {
        _isFacingRight = true;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _horizontalValue = Input.GetAxisRaw("Horizontal");
        _xVelocity = _speed * _horizontalValue;
        Vector2 targetVelocity = new Vector2(_xVelocity, _rigidbody.velocity.y);
        _rigidbody.velocity = targetVelocity;

        if (_isFacingRight && _horizontalValue < 0)
        {
            _isFacingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if(_isFacingRight == false && _horizontalValue > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            _isFacingRight = true;
        }

        _animator.SetFloat("Horizontal", Mathf.Abs(_rigidbody.velocity.x));
    }
}
