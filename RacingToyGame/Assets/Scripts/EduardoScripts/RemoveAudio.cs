using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAudio : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
}
