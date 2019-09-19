using System;
using UnityEngine;

public class MostrarFaro : DefaultTrackableEventHandler
{
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnTrackingFound()
    {
        Debug.Log("Encontrado");
        GetComponentInChildren<SubirFaro>().Reiniciar();
        base.OnTrackingFound();
    }

    protected override void OnTrackingLost()
    {
        Debug.Log("Perdido");
        base.OnTrackingLost();
    }
}
