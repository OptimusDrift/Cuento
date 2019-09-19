using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav : MonoBehaviour
{
    public Transform[] destinos;
    public Transform objTrans;
    public float velocidad;
    public float velocidadGiro;
    public float tiempoDeAccion;
    public float tiempoPausa;
    private int puntero;
    private NavMeshAgent objNav;
    private bool encoger;
    private bool enormizar;
    private bool bajando;
    private bool subiendo;
    private float x;
    private float y;
    private float z;
    private float tiempoDeAccionContador;
    private bool pausa;

    // Start is called before the first frame update
    void Start()
    {
        objNav = GetComponent<NavMeshAgent>();
        puntero = 0;
        objNav.SetDestination(destinos[puntero].position);
        objNav.Warp(destinos[puntero].position);
        encoger = false;
        enormizar = false;
        bajando = false;
        subiendo = false;
        pausa = false;
        x = 1;
        y = 1;
        z = 1;
        tiempoDeAccionContador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshBuilder.UpdateNavMeshData();
        if (encoger)
        {
            if (objTrans.localScale.x >= 0f)
            {
                CambiarTamanno(-velocidad * Time.deltaTime);
            }
            else
            {
                encoger = false;
            }
        }

        if (enormizar)
        {
            if (objTrans.localScale.x <= 1f)
            {
                CambiarTamanno(velocidad * Time.deltaTime);
            }
            else
            {
                enormizar = false;
            }
        }

        if (bajando)
        {
            RotarAbajo(velocidad * Time.deltaTime);
        }

        if (subiendo)
        {
            RotarArriba(velocidad * Time.deltaTime);
        }
        tiempoDeAccionContador -= Time.deltaTime;
        Debug.Log(tiempoDeAccionContador);
        if (tiempoDeAccionContador <= 0)
        {
            bajando = false;
            subiendo = false;
            if (pausa)
            {
                Debug.Log("asd");
                PunteroSiguiente();
                objNav.SetDestination(destinos[puntero].position);
                objNav.Warp(destinos[puntero].position);
                pausa = false;
            }
        }
    }

    void CambiarTamanno(float velocidad)
    {
        x += velocidad;
        y += velocidad;
        z += velocidad;
        objTrans.localScale = new Vector3(x, y, z);
    }

    void RotarAbajo(float velocidad)
    {
        objTrans.Rotate(velocidadGiro, 0, 0);
    }
    void RotarArriba(float velocidad)
    {
        objTrans.Rotate(-velocidadGiro, 0, 0);
    }
    void PunteroSiguiente()
    {
        puntero++;
        if (puntero >= destinos.Length)
        {
            puntero = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Siguiente"))
        {
            PunteroSiguiente();
            objNav.SetDestination(destinos[puntero].position);
            objNav.Warp(destinos[puntero].position);
        }
        if (other.tag.Equals("Pausa"))
        {
            pausa = true;
            tiempoDeAccionContador = tiempoPausa;
        }
        if (other.tag.Equals("Encoger"))
        {
            encoger = true;
        }
        if (other.tag.Equals("Enormizar"))
        {
            enormizar = true;
        }
        if (other.tag.Equals("Bajada"))
        {
            bajando = true;
            tiempoDeAccionContador = tiempoDeAccion;
        }
        if (other.tag.Equals("Subida"))
        {
            subiendo = true;
            tiempoDeAccionContador = tiempoDeAccion;
        }
    }
}
