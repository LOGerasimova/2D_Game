using UnityEngine;
using UnityEngine.UI;

public class Boss_health_script : MonoBehaviour
{
    [SerializeField] private int _hp = 25;
    [SerializeField] private int _dm = 1;
    [SerializeField] private GameObject _gameController;
    [SerializeField] private Image _hpBar;

    private float _one = 1f;


    public void TakeDamage(int dmg)
    {
        _hp -= dmg;

        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
        _one -= 0.04f;
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
