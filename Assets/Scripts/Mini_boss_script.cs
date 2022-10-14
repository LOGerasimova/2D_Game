using UnityEngine;

public class Mini_boss_script : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private GameObject _player;

    private float _distence;    

    private Vector3 _dir = new Vector3(-1, 0, 0);
    private Rigidbody2D _myRb;
    public bool facingRight = true;
    private bool _chase = false;
    private bool _left = true;

    private Animator _anim;

    public float _distance;

    void Start()
    {
        _myRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _distence = GetComponent<Collider2D>().bounds.extents.x + 7f;
    }

    void Update()
    {
        _distance = Vector3.Distance(_player.transform.position, transform.position);

        if (_chase == true && _distance > 3f)
        {
            if (!facingRight)
                Flip();

            _myRb.AddForce(Vector3.right * _speed * _dir.x, ForceMode2D.Impulse);

            _anim.SetBool("idle", false);

            if (Mathf.Abs(_myRb.velocity.x) > _speed)
            {
                Vector2 velocity = _myRb.velocity;
                velocity.x = _speed * Mathf.Sign(_myRb.velocity.x);
                _myRb.velocity = velocity;
            }
        }
        else if (_chase == true && _distance <= 3f)
        {
            _anim.SetBool("attak", true);
        }

        else if (_chase == false)
        {
            _anim.SetBool("attak", false);
            _anim.SetBool("idle", true);
        }
    }

    private void FixedUpdate()
    {
        DrawRay();
    }

    private void DrawRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, _distence, _mask);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right, _distence, _mask);

        if (hit != false && hit2 == false)
        {
            if (_left == false)
                facingRight = false;
            _left = true;
            _chase = true;
        }
        else if(hit2 != false && hit == false)
        {
            if (_left == true)
                facingRight = false;
            _left = false;
            _chase = true;
        }
        else _chase = false;



        Debug.DrawRay(transform.position, -Vector2.right * _distence, Color.red);
        Debug.DrawRay(transform.position, Vector2.right * _distence, Color.red);
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
