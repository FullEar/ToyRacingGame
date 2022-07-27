using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Contador : MonoBehaviour
{   public TextMeshProUGUI contadortxt;
    public int numerodechecckpoints = 10;
    public UnityEvent eventoGanar;

    private int numeroactual;




    // Start is called before the first frame update
    void Start()
    {
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        contadortxt.text = numeroactual.ToString() + " / " + numerodechecckpoints.ToString();
    }

    public void AgregarUnoCheckpoint()
    {
        numeroactual++;
        ActualizarTexto();
        Ganar();
    }

    private void Ganar()
    {
        if (numeroactual >= numerodechecckpoints)
        {
            eventoGanar.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
