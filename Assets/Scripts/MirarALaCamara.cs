using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarALaCamara : MonoBehaviour
{
    public GameObject[] imagenes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in imagenes)
        {
            item.GetComponent<Transform>().rotation = GetComponent<Camera>().GetComponent<Transform>().rotation;
        }
    }
}
