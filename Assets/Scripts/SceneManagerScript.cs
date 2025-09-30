using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMangerScript : MonoBehaviour
{
    public RaycastSight Raycast;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Animated_Character_Navigation_Final");

    }

    // Update is called once per frame
    void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (Raycast.enContacto == true)
        {
            SceneManager.LoadScene("EscenaPerder");

        }
        if (currentSceneName == "Perder" && Input.GetKeyDown(KeyCode.R))
        {
        SceneManager.LoadScene("Animated_Character_Navigation_Final");
    }
    }
}
