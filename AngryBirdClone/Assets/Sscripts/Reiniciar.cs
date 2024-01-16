using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{
    public string levelName = "SampleScene"; // Cambia esto al nombre del nivel actual

    public void ResetLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
