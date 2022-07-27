using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChecckPointScrip : MonoBehaviour
{
    private TracklChechPoint tracklChechPoint;
    private MeshRenderer meshRenderer;

    [SerializeField] private string tagName = "Player";
    [SerializeField] private UnityEvent coleccionado;

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
            coleccionado.Invoke();
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
