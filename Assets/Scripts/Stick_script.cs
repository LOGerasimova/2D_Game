using UnityEngine;

public class Stick_script : MonoBehaviour
{
    [SerializeField] private GameObject _gameController;
    [SerializeField] private int _dm = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameController.GetComponent<Game_controller_script>().TakeDM(_dm);

        }
    }
}
