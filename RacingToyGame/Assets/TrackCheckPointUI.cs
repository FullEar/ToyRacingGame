using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckPointUI : MonoBehaviour
{
    [SerializeField] private TracklChechPoint tracklChechPoint;

    private void Start()
    {
        tracklChechPoint.OnPlayerCorrectCheckPoint += TracklCheckPoint_OnPlayerCorrectCheckpoint;
        tracklChechPoint.OnPlayerIncorrectCheckPoint += TracklChechPoint_OnPlayerIncorrectCheckpoint;
        Hide();
    }

    private void TracklChechPoint_OnPlayerIncorrectCheckpoint(object sender, System.EventArgs e)
    {
        Show();
    }
    private void TracklCheckPoint_OnPlayerCorrectCheckpoint(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Show ()
    {
        gameObject.SetActive(true);
    }
    private void Hide ()
    {
        gameObject.SetActive(false);
    }

}
