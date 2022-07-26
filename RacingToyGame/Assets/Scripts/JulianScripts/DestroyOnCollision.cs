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
            StartCoroutine(WaitforRespawn(collision.collider.gameObject));
            foreach(var evento in eventos)
            {
                evento.Invoke();
            }
            collision.gameObject.SetActive(false);
        }
    }
    private IEnumerator WaitforGameOver()
    {
        timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        GameOver();
    }

    private IEnumerator WaitforRespawn(GameObject player)
    {
        timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        player.SetActive(true);
        player.GetComponent<Controller>().Respawn();
    }
}
