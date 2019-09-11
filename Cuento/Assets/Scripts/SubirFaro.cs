using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirFaro : MonoBehaviour
{
    private Transform ObjetoASubir;
    public float Velocidad;
    float x;
    float y;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        ObjetoASubir = GetComponent<Transform>();
        x = 0;
        y = 0;
        z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjetoASubir.localScale.x < 1f)
        {
            x += Velocidad * Time.deltaTime;
            y += Velocidad * Time.deltaTime;
            z += Velocidad * Time.deltaTime;
            ObjetoASubir.localScale = new Vector3(x,y,z);
        }
    }
}
