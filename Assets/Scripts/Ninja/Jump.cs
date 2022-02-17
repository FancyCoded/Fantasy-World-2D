using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private Transform _groundCheckCollider;
    [SerializeField] LayerMask _groundLayer;
    
    private int _jumpForce;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private float _groundCheckRadius = 0.1f;
    private bool _isGrounded;

    private void Start()
    {
        _jumpForce = 500;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GroundCheck();
        JumpUp();
    }

    private void JumpUp()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _rigidbody.velocity.y == 0)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _animator.SetBool("Jump", true);
            _animator.SetBool("isGrounded", _isGrounded);
        }
    }

    private void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheckCollider.position, _groundCheckRadius, _groundLayer);

        if(colliders.Length > 0)
        {
            _isGrounded = true;
            _animator.SetBool("Jump", false);
            _animator.SetBool("isGrounded", _isGrounded);
        }
        else
        {
            _isGrounded = false;
        }
    }
}
