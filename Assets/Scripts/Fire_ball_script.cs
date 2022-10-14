
using UnityEngine;

public class Fire_ball_script : MonoBehaviour
{
    [SerializeField] public float _speed = 30;
    [SerializeField] private float _lifeTime = 1;
    [SerializeField] private float _lifeTimefire = 0.1f;
    [SerializeField] private int _damage = 1;

    public GameObject _FB_Destroy;
    private GameObject cloneBomb;
    public bool facingRight = true;
    private Rigidbody2D _myRb;
    public Vector3 _dir = new Vector3(1, 0, 0);

    void Start()
    {
        Destroy(gameObject, _lifeTime);
        _myRb = GetComponent<Rigidbody2D>();
        if (!facingRight)
            Flip();
    }

    void Update()
    {
        _myRb.AddForce(Vector3.right * _speed * _dir.x, ForceMode2D.Impulse);

        if (Mathf.Abs(_myRb.velocity.x) > _speed)
        {
            Vector2 velocity = _myRb.velocity;
            velocity.x = _speed * Mathf.Sign(_myRb.velocity.x);
            _myRb.velocity = velocity;
        }

        //transform.position += transform.right * _speed * _dir.x * Time.deltaTime;
    }

    void Flip()
    {
        facingRight = !facingRight;
        _dir.x *= -1;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var health = collision.gameObject.GetComponent<Enemy_health_script>();
            //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            health.TakeDamage(_damage);
            cloneBomb = Instantiate(_FB_Destroy, transform.position, transform.rotation);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            var health = collision.gameObject.GetComponent<Boss_health_script>();
            //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            health.TakeDamage(_damage);
            cloneBomb = Instantiate(_FB_Destroy, transform.position, transform.rotation);
        }
        if (collision.gameObject.CompareTag("MiniBoss"))
        {
            var health = collision.gameObject.GetComponent<Mini_boss_health_script>();
            //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            health.TakeDamage(_damage);
            cloneBomb = Instantiate(_FB_Destroy, transform.position, transform.rotation);
        }

        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(cloneBomb, _lifeTimefire);
            Destroy(gameObject);
        }

    }

}
