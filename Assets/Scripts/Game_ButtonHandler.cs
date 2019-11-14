using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_ButtonHandler : MonoBehaviour
{
    public void backToMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
