
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_controller_script : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    public GameObject _player;
    public bool _pause = false;

    public Text HPText;
    public Text CointText;
    public Text SoulText;
    public Text KeyText;

    public int _HP = 10;
    public int _coin = 0;
    public int _soul = 0;
    public int _key = 0;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        HPText.text = "HP: " + _HP;
        CointText.text = "Coin: " + _coin;
        SoulText.text = "Soul: " + _soul;
        KeyText.text = "Key: " + _key;

        if (_HP <= 0)
        {
            _player.GetComponent<Player_controller_script>().Die();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    public void Pause()
    {
        _pause = true;
        _menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        _pause = false;
        _menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void TakeCoin(int coin)
    {
        _coin += coin;
    }
    public void TakeSoul(int soul)
    {
        _soul += soul;
    }
    public void TakeKey(int key)
    {
        _key += key;
    }
    public void TakeDM(int dm)
    {
        _HP -= dm;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
