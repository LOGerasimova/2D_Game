using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller_script : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    Vector3 vec3;

    void Update()
    {
        vec3 = new Vector3(_player.transform.position.x, _player.transform.position.y, -50f);
        transform.position = vec3;
    }
}
