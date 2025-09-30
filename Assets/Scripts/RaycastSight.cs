using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class RaycastSight : MonoBehaviour
{
    [SerializeField] Transform originTR;
    [SerializeField] float rayLenght = 3f;
    public bool jugadorVisible = false;
    public float tiempoSinVer = 0f;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;

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
                tiempoSinVer += Time.deltaTime;
            }
        }
        if (tiempoSinVer > 2)
        {
            jugadorVisible = false;
            Debug.Log("Jugador no detectado");
        }

    }

}
