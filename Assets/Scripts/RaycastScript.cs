using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    [SerializeField] Transform originTR;   
    [SerializeField] float rayLenght = 3f; 
    [SerializeField] float tiempoPerdida = 2f; 
    private float tiempoSinVer = 0f;
    public bool enContacto = false;
    public bool jugadorVisible = false;
    public float touchDistance = 0.5f;

    void Start()
    {
        if (originTR == null) originTR = transform; 
    }

    void Update()
    {


        RaycastHit hitInfo;

        // Disparo del raycast
        if (Physics.Raycast(originTR.position, originTR.forward, out hitInfo, rayLenght))
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                jugadorVisible = true;
                tiempoSinVer = 0f; 
                Debug.Log("Jugador detectado!");
            }
            else
            {
           
                jugadorVisible = false;
            }
        }
        else
        {
            jugadorVisible = false;
        }

        if (!jugadorVisible)
        {
            tiempoSinVer += Time.deltaTime;

            if (tiempoSinVer >= tiempoPerdida)
            {
                Debug.Log("Jugador no visible");
                tiempoSinVer = 0f; 
                jugadorVisible = false;
            }
        }
        
    }

    void OnDrawGizmos()
    {
        if (originTR == null) originTR = transform;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(originTR.position, originTR.position + originTR.forward * rayLenght);
    }
}
