using UnityEngine;
using UnityEngine.UI;

public class Mini_boss_health_script : MonoBehaviour
{
    [SerializeField] private int _hp = 16;
    [SerializeField] private int _dm = 1;
    [SerializeField] private GameObject _gameController;
    [SerializeField] private Image _hpBar;

    private float _one = 1f;
    public GameObject _key;

    private void Update()
    {
        
    }

    public void TakeDamage(int dmg)
    {
        _hp -= dmg;

        if (_hp <= 0)
        {
            Instantiate(_key, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        _one -= 0.0625f;
        _hpBar.fillAmount = _one;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameController.GetComponent<Game_controller_script>().TakeDM(_dm);

        }
    }
}
