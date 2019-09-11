using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrenNav : MonoBehaviour
{
    public Transform[] destinos;
    public Transform objTren;
    public float velocidad;
    public float velocidadGiro;
    private int puntero;
    private NavMeshAgent tren;
    private Transform ubicacionTren;
    private bool encoger;
    private bool enormizar;
    private bool bajando;
    private bool subiendo;
    private float rotacionActual;
    private float x;
    private float y;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        tren = GetComponent<NavMeshAgent>();
        ubicacionTren = GetComponent<Transform>();
        puntero = 0;
        tren.SetDestination(destinos[puntero].position);
        encoger = false;
        enormizar = false;
        bajando = false;
        subiendo = false;
        rotacionActual = 0f;
        x = 1;
        y = 1;
        z = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (encoger)
        {
            if (objTren.localScale.x >= 0f)
            {
                CambiarTamanno(-velocidad * Time.deltaTime);
            }
            else
            {
                encoger = !encoger;
            }
        }

        if (enormizar)
        {
            if (objTren.localScale.x <= 1f)
            {
                CambiarTamanno(velocidad * Time.deltaTime);
            }
            else
            {
                enormizar = !enormizar;
            }
        }

        if (bajando)
        {
            Debug.Log(rotacionActual);
            Debug.Log(objTren.localRotation.x);
            if (objTren.localRotation.x < rotacionActual / 100f)
            {
                Debug.Log("girando x2");
                Rotar(velocidad * Time.deltaTime);
            }
            else
            {
                Debug.Log("fail");
                bajando = !bajando;
            }
        }

        if (subiendo)
        {
            Debug.Log(rotacionActual);
            Debug.Log(objTren.localRotation.x);
            if (objTren.localRotation.x < rotacionActual / 100f)
            {
                Debug.Log("girando x2");
                Rotar(velocidad * Time.deltaTime);
            }
            else
            {
                Debug.Log("fail");
                subiendo = !subiendo;
            }
        }
    }

    void CambiarTamanno(float velocidad)
    {
        x += velocidad;
        y += velocidad;
        z += velocidad;
        objTren.localScale = new Vector3(x, y, z);
    }

    void Rotar(float velocidad)
    {
        objTren.Rotate(velocidadGiro, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        puntero++;
        if (puntero >= destinos.Length)
        {
            puntero = 0;
        }
        //tren.SetDestination(destinos[puntero].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Encoger"))
        {
            encoger = true;
            puntero = 1;
            tren.SetDestination(destinos[puntero].position);
        }
        if (other.tag.Equals("Enormizar"))
        {
            enormizar = true;
            if (puntero == 1)
            {
                puntero = 2;
            }
            else
            {
                puntero = 0;
            }
            tren.SetDestination(destinos[puntero].position);
            objTren.localRotation = new Quaternion(0, 0, 0, 0);
            objTren.Rotate(other.GetComponent<Valor>().x, 0, 0);
            //objTren.localRotation = new Quaternion(30f, 0, 0, 0);
        }
        if (other.tag.Equals("Bajada"))
        {
            bajando = true;
            rotacionActual = other.GetComponent<Valor>().x;
        }
        if (other.tag.Equals("Subida"))
        {
            subiendo = true;
            rotacionActual = other.GetComponent<Valor>().x;
        }
    }
}
