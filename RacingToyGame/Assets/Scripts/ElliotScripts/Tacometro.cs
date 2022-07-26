using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tacometro : MonoBehaviour
{
    // Arrastrar carro acá para tomar su rigidbody
    public Rigidbody rbCarro;

    // Barra a llenar
    public Image imageFillBar;

    // Texto de los numeros de la velocidad
    public TextMeshProUGUI txtNumeros;

    public float speed = 0f;
    public float maxSpeed = 53f;

    private float progress;

    private void Update()
    {
        // Km/hr.
        speed = rbCarro.velocity.magnitude * 1.8f;
        progress = speed / maxSpeed;
        imageFillBar.fillAmount = Mathf.Lerp(0, 1, progress);
        txtNumeros.text = (int)speed + "kph";
    }
}