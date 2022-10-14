using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_pig_script : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _dir = new Vector3(-1, 0, 0);
    private Rigidbody2D _myRb;
    public bool facingRight = true;

    private Animator _anim;


    void Start()
    {
        _myRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!facingRight)
            Flip();

        _myRb.AddForce(Vector3.right * _speed * _dir.x, ForceMode2D.Impulse);


        if (Mathf.Abs(_myRb.velocity.x) > _speed)
        {
            Vector2 velocity = _myRb.velocity;
            velocity.x = _speed * Mathf.Sign(_myRb.velocity.x);
            _myRb.velocity = velocity;
        }

        if (_dir.x != 0)
        {  
            _anim.SetBool("walk", true);
        }


        if (_dir.x == 0)
        {
            _anim.SetBool("walk", false);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        _dir.x *= -1;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
