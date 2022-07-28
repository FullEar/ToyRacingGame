using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "TutorialLevel")
            BGMusic.instance.GetComponent<AudioSource>().Pause();

        if (SceneManager.GetActiveScene().name == "FirstLevel")
            BGMusic.instance.GetComponent<AudioSource>().Pause();

        if (SceneManager.GetActiveScene().name == "SecondLevel")
            BGMusic.instance.GetComponent<AudioSource>().Pause();
    }
}
