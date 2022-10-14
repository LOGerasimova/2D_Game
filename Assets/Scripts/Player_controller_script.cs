using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller_script : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;
    [SerializeField] private GameObject _fireBall;
    [SerializeField] private GameObject _fireBallSpawn;
    [SerializeField] private GameObject _gameController;
    [SerializeField] private LayerMask _mask;

    private float _distence;
    //private Vector2 _radius;
    private Vector3 _dir;
    public bool _isGrounded = true;
    private Rigidbody2D _myRb;
    public bool facingRight = true;
    
    private Animator _anim;


    void Start()
    {
        _myRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _distence = GetComponent<Collider2D>().bounds.extents.y + 0.1f;
        //_radius = GetComponent<Collider2D>().bounds.size;
        //_radius.x += 0.1f;
    }

    void Update()
    {
        _dir.x = Input.GetAxis("Horizontal");

        if (_dir.x > 0 && !facingRight)
            Flip();
        else if (_dir.x < 0 && facingRight)
            Flip();

        if (_dir.x != 0)
        {
            _myRb.AddForce(Vector3.right * _speed * _dir.x, ForceMode2D.Impulse);
            //transform.position += _dir * _speed * Time.deltaTime;
            _anim.SetBool("walk", true);
        }

        //var hit = Physics2D.OverlapCapsule(transform.position, _radius, CapsuleDirection2D.Vertical, 0, _mask);
        //Debug.DrawRay(transform.position, Vector2.right * _radius, Color.red);
        //if (hit)
        //{
        //    //Vector2 velocity = _myRb.velocity;
        //    //velocity.x = 0;
        //    //_myRb.velocity = velocity;
        //    _dir.x = 0;
        //}

        if (Mathf.Abs(_myRb.velocity.x)>_speed)
        {
            Vector2 velocity = _myRb.velocity;
            velocity.x = _speed * Mathf.Sign(_myRb.velocity.x);
            _myRb.velocity = velocity;
        }

        if (_dir.x == 0)
        {
            _anim.SetBool("walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(Input.GetMouseButtonDown(0) && _gameController.GetComponent<Game_controller_script>()._pause == false)
        {
            Fire();
            _anim.SetBool("attack", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _anim.SetBool("attack", false);
        }

    }

    private void FixedUpdate()
    {
        DrawRay();

        
    }

    private void DrawRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _distence, _mask);

        if (hit != false)
        {
            _isGrounded = true;

           // _anim.SetBool("jump", false);
        }
        else _isGrounded = false;

        Debug.DrawRay(transform.position, Vector2.down * _distence, Color.red);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platforma") || collision.gameObject.CompareTag("PlatformaVertical"))
            _isGrounded = true;
        _anim.SetBool("jump", false);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platforma") || collision.gameObject.CompareTag("PlatformaVertical"))
            _isGrounded = false;
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _myRb.AddForce(Vector3.up * _jump, ForceMode2D.Impulse);
            _anim.SetBool("jump", true);
        }
    }

    public void Fire()
    {
        GameObject _fire = Instantiate(_fireBall, _fireBallSpawn.transform.position, _fireBallSpawn.transform.rotation) as GameObject;
        if (!facingRight)
            _fire.GetComponent<Fire_ball_script>().facingRight = facingRight;
    }

    public void Die()
    {
        _anim.SetBool("die", true);
    }


    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
