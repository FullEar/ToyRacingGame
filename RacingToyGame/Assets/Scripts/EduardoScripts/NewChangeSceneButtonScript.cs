using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewChangeSceneButtonScript : MonoBehaviour
{
    public string scene;

    public void SceneSelection()
    {
        SceneManager.LoadScene("scene");
    }
}
