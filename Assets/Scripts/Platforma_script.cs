
using UnityEngine;

public class Platforma_script : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private Vector3 _dir = new Vector3(1, 0, 0);
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

        _myRb.AddForce(Vector3.right * _speed * _dir.x, ForceMode2D.Impulse);

        if (Mathf.Abs(_myRb.velocity.x) > _speed)
        {
            Vector2 velocity = _myRb.velocity;
            velocity.x = _speed * Mathf.Sign(_myRb.velocity.x);
            _myRb.velocity = velocity;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        _dir *= -1;
    }

    //void Start()
    //{
    //}

    //void Update()
    //{
    //    if (!facingRight)
    //        Flip();
    //    transform.position += _dir * _speed * Time.deltaTime;

    //}

    //void Flip()
    //{
    //    facingRight = !facingRight;
    //    _dir *= -1;
    //}
}
