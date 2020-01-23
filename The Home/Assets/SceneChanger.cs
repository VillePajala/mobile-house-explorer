using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Tällä metodilla mennään menusta itse "peliin". Liitetään nappiin
    public void nextScene()
    {
        SceneManager.LoadScene(0);
    }
    // Tällä metodilla avataan menu. Liitetään nappiin
    public void menuScene()
    {
        SceneManager.LoadScene(1);
    }
}

