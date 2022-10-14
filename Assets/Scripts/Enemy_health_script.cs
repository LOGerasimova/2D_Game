using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health_script : MonoBehaviour
{
    [SerializeField] private int _hp = 2;
    [SerializeField] private int _dm = 1;

    private GameObject _game_controller;

    public GameObject fire;

    void Awake()
    {
        _game_controller = GameObject.Find("GameController");
    }


    public void TakeDamage(int dmg)
    {
        _hp -= dmg;

        if (_hp <= 0)
        {
            Instantiate(fire, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _game_controller.GetComponent<Game_controller_script>().TakeDM(_dm);

        }
    }
}
