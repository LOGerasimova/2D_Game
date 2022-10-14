using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_script : MonoBehaviour
{
    [SerializeField] private int _key = 1;
    //private GameObject key;
    private GameObject _game_controller;


    private void Start()
    {
        _game_controller = GameObject.Find("GameController");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _game_controller.GetComponent<Game_controller_script>().TakeKey(_key);
            Destroy(gameObject);
        }
    }
}
