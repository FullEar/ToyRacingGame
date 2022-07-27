using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracklChechPoint : MonoBehaviour
{
    public event EventHandler OnPlayerCorrectCheckPoint;
    public event EventHandler OnPlayerIncorrectCheckPoint;


    private List<ChecckPointScrip> checKpointSingleList;
    private int nextCheckpointSingleIndex; 

    public Transform[] checkpointsTransform;

    private void Awake()
    {  
        checKpointSingleList = new List<ChecckPointScrip>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
           ChecckPointScrip checckPointScrip = checkpointSingleTransform.GetComponent<ChecckPointScrip>();
            checckPointScrip.SetTrackCheckpoints(this); 
            checKpointSingleList.Add(checckPointScrip);
        }
        nextCheckpointSingleIndex = 0;
    }


    public void PlayerThroughCheckpoint(ChecckPointScrip checkPointScrip)
    { 
        if (checKpointSingleList.IndexOf(checkPointScrip) == nextCheckpointSingleIndex)
        {
            Debug.Log("Correcto");


            ChecckPointScrip correctCheckpointsingle = checKpointSingleList[nextCheckpointSingleIndex];
            correctCheckpointsingle.Hide();

            nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checKpointSingleList.Count;
            OnPlayerCorrectCheckPoint?.Invoke(this, EventArgs.Empty);
        }

    
        else
        {
            Debug.Log("INCORRECTO");
            OnPlayerIncorrectCheckPoint?.Invoke(this, EventArgs.Empty);

            ChecckPointScrip correctCheckpointsingle = checKpointSingleList[nextCheckpointSingleIndex];
            correctCheckpointsingle.Show();
        }
    }

        
}
