using System;
using UnityEngine;
using Shooter.Interactions;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour, IMoveable
{
    [Header("Stats")]
    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private float _jumpHeight = 3f;

    [SerializeField]
    private LayerMask _ground;

    [SerializeField]
    private Rigidbody _ridigbody;

    [SerializeField]
    private CapsuleCollider _capsuleCollider;

    [SerializeField]
    private PlayerSettings _playerSettings;
    private bool _isGrounded;

    private Vector2 _axis;
    private Vector2 _turn;

    public float Speed => _speed;

    private void Update()
    {
        SetAxis();
        SetTurn();

        transform.rotation = Quaternion.Euler(0, Input.GetAxis("Mouse X"), 0);
    }

    private void SetAxis()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _axis = new Vector2(horizontal, vertical);
    }

    private void SetTurn()
    {
        _turn.x += Input.GetAxis("Mouse X");
        _turn.y += Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        CheckIsGrounded();
        Move();
        Jump();
    }

    private void CheckIsGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, _capsuleCollider.height / 2 + .1f, _ground))
            _isGrounded = true;
        else
            _isGrounded = false;
    }

    private void Move()
    {
        var move = new Vector3(_axis.x, 0, _axis.y);

        _ridigbody.MovePosition(transform.position + (move * _speed * Time.fixedDeltaTime));
    }

    private void Rotate()
    {

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _ridigbody.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
        }
    }
}
