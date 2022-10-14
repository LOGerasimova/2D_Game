using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_script : MonoBehaviour
{
    [SerializeField] LayerMask _mask;
    [SerializeField] float _distence;

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, _distence, _mask);

        if (hit != false)
            print(hit.collider.gameObject.name);

        Debug.DrawRay(transform.position, Vector2.right * _distence, Color.red);
    }
}
