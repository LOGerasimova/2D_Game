using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_going_script : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var facingRight = collision.GetComponent<Enemy_pig_script>().facingRight;
            facingRight = !facingRight;
            collision.GetComponent<Enemy_pig_script>().facingRight = facingRight;
        }

        //if (collision.gameObject.CompareTag("Boss"))
        //{
        //    var facingRight = collision.GetComponent<Mini_boss_script>().facingRight;
        //    facingRight = !facingRight;
        //    collision.GetComponent<Mini_boss_script>().facingRight = facingRight;
        //}

        if (collision.gameObject.CompareTag("Platforma"))
        {
            var facingRight = collision.GetComponent<Platforma_script>().facingRight;
            facingRight = !facingRight;
            collision.GetComponent<Platforma_script>().facingRight = facingRight;
        }
        if (collision.gameObject.CompareTag("PlatformaVertical"))
        {
            var facingRight = collision.GetComponent<Platforma_verticoll_script>().facingRight;
            facingRight = !facingRight;
            collision.GetComponent<Platforma_verticoll_script>().facingRight = facingRight;
        }

    }
    
}
