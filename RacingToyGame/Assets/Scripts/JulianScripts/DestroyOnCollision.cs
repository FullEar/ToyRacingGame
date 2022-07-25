using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOnCollision : MonoBehaviour
{
    [Header("Canvas de GameOver")]
    public GameObject pantallaGameOver;

    [Header("Timer")]
    public float timer = 0f;
    public float duration = 1f;

    [Header("Eventos")]
    public UnityEvent[] eventos;


    public void GameOver()
    {
        pantallaGameOver.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine("WaitforGameOver");
            foreach(var evento in eventos)
            {
                evento.Invoke();
            }
            collision.gameObject.SetActive(false);
        }
    }
    private IEnumerator WaitforGameOver()
    {
        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        GameOver();
    }
}
