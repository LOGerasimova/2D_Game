using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes_script : MonoBehaviour
{
    [SerializeField] private int _dm = 1;
    [SerializeField] private GameObject _game_controller;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _game_controller.GetComponent<Game_controller_script>().TakeDM(_dm);

        }
    }
}
