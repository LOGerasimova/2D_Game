using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_script : MonoBehaviour
{
    [SerializeField] private GameObject _spawn;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _spawnCoin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < _spawn.transform.childCount; i++)
        {
            Instantiate(_enemy, _spawn.transform.GetChild(i).position, _spawn.transform.GetChild(i).rotation);

            Destroy(_spawn);
        }

        for (int i = 0; i < _spawnCoin.transform.childCount; i++)
        {
            Instantiate(_coin, _spawnCoin.transform.GetChild(i).position, _spawnCoin.transform.GetChild(i).rotation);

            Destroy(_spawnCoin);
        }

        Destroy(gameObject);
    }
}
