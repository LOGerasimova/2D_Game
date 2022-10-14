using System.Collections;

using UnityEngine;

public class Platform5_script : MonoBehaviour
{

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for(int i = 0; i<4; i++)
            {
                yield return new WaitForSeconds(0.3f);

                for (int j = 0; j < transform.childCount; j++)
                {
                    transform.GetChild(j).gameObject.SetActive(false);
                }

                yield return new WaitForSeconds(0.3f);

                for (int j = 0; j < transform.childCount; j++)
                {
                    transform.GetChild(j).gameObject.SetActive(true);
                }
            }

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            gameObject.GetComponent<Collider2D>().enabled = false;

            yield return new WaitForSeconds(3);

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }


}
