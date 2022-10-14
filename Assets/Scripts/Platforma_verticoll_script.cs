using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforma_verticoll_script : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private Vector3 _dir = new Vector3(0, 1, 0);
    public bool facingRight = true;


    private Rigidbody2D _myRb;

    void Start()
    {
        _myRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!facingRight)
            Flip();

        _myRb.AddForce(Vector3.up * _speed * _dir.y, ForceMode2D.Impulse);

        if (Mathf.Abs(_myRb.velocity.y) > _speed)
        {
            Vector2 velocity = _myRb.velocity;
            velocity.y = _speed * Mathf.Sign(_myRb.velocity.y);
            _myRb.velocity = velocity;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        _dir *= -1;
    }
}
