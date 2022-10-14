using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_script : MonoBehaviour
{
    //обработчик нажания кнопки
    public void LoadLevel(int numLvl)
    {
        SceneManager.LoadScene(numLvl);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
