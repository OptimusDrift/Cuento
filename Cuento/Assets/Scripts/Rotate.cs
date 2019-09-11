using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Transform ObjetoARotar;
    public float Velocidad;
    private bool rebote;
    // Start is called before the first frame update
    void Start()
    {
        ObjetoARotar = GetComponent<Transform>();
        rebote = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjetoARotar.rotation.x <= 0.8f && !rebote)
        {
            ObjetoARotar.Rotate(Velocidad * Time.deltaTime, ObjetoARotar.rotation.y, ObjetoARotar.rotation.z);
        }
        if (ObjetoARotar.rotation.x >= 0.8f)
        {
            rebote = true;
        }
        if (rebote && ObjetoARotar.rotation.x >= 0.7f)
        {
            ObjetoARotar.Rotate(-Velocidad * Time.deltaTime, ObjetoARotar.rotation.y, ObjetoARotar.rotation.z);
        }
    }
}
