using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_script : MonoBehaviour
{
    [SerializeField] private GameObject _portal;
    [SerializeField] private GameObject _porta2;
    [SerializeField] private GameObject _gameController;

    private bool _porta = false;

    private Animator _anim;

    IEnumerator Start()
    {
        _portal = GameObject.Find("Portal");
        _anim = _portal.GetComponent<Animator>();
        yield return new WaitForSeconds(0.2f);
        _anim.SetBool("open", false);
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _gameController.GetComponent<Game_controller_script>()._key != 0)
        {
            _gameController.GetComponent<Game_controller_script>()._key--;
            yield return new WaitForSeconds(1);
            if(_porta == false)
                collision.gameObject.transform.position = _porta2.transform.position;
            else if (_porta == true)
                collision.gameObject.transform.position = _portal.transform.position;
            _porta = !_porta;
        }
    }


}
