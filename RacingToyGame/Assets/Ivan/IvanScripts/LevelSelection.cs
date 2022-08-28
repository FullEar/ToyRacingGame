using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void LevelOneScene()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void CarSelectionLevel()
    {
        SceneManager.LoadScene("CarSelection");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelectionButton()
    {
        SceneManager.LoadScene("LevelSelection");
    }
}
