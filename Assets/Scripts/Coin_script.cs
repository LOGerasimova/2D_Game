using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_script : MonoBehaviour
{
    [SerializeField] private int _coin = 1;
    //private GameObject coin;
    private GameObject _game_controller;

    //game_controller_script game_controller;

    private void Start()
    {
        _game_controller = GameObject.Find("GameController");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _game_controller.GetComponent<Game_controller_script>().TakeCoin(_coin);
            Destroy(gameObject);
        }
    }
}
