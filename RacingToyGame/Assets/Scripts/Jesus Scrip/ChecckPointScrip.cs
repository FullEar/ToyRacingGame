using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecckPointScrip : MonoBehaviour
{
    private TracklChechPoint tracklChechPoint;
    private MeshRenderer meshRenderer;

    [SerializeField] private string tagName = "Player";

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();    
    }
    private void OnTriggerEnter (Collider other)
  {
    if (other.CompareTag(tagName)) 
    {
        Debug.Log("Checklpoint!");
            tracklChechPoint.PlayerThroughCheckpoint(this);
    }
  }
  public void SetTrackCheckpoints(TracklChechPoint tracklChechPoint)
    {

        this.tracklChechPoint= tracklChechPoint;
    }

    public    void Show ()
    {
        meshRenderer.enabled = true;    
    }

    public void Hide ()
    {
        meshRenderer.enabled = false;
    }
}
