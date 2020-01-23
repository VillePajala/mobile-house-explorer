using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDefaults : MonoBehaviour
{
    // Määritellään eri koordinaatteja 3D -avaruuteen
    Vector3 destinationTop = new Vector3(0f, 20f, 1f);
    Vector3 destinationFront = new Vector3(-0.12f, 0.7f, -10.5f);
    Vector3 destinationSide = new Vector3(10f, 0.7f, 0f);
    Vector3 destinationSide2 = new Vector3(-13f, 0.7f, 0.5f);
    Vector3 destinationBack = new Vector3(-0.5f, 0.7f, 10.5f);

    // Määritellään kameran kulmia 3D -avaruudessa
    Quaternion rotationTop = Quaternion.Euler(90, 0, 0);
    Quaternion rotationFront = Quaternion.Euler(0, 0, 0);
    Quaternion rotationSide = Quaternion.Euler(0, -90, 0);
    Quaternion rotationSide2 = Quaternion.Euler(0, 90, 0);
    Quaternion rotationBack = Quaternion.Euler(0, 180, 0);

    private GameObject kamera = null;

    void Start()
    {
        this.kamera = GameObject.Find("Camera");
    }


    // Tehdään metodeja, jotka asettavat kameran haluttuun paikkaan ja haluttuun kulmaan
    // Nämä metodit liitetään UI -nappeihin
    public void topCamera()
    {
        this.kamera.GetComponent<Transform>().position = destinationTop;
        this.kamera.GetComponent<Transform>().rotation = rotationTop;
    }
    public void frontCamera()
    {
        this.kamera.GetComponent<Transform>().position = destinationFront;
        this.kamera.GetComponent<Transform>().rotation = rotationFront;
    }
    public void sideCamera()
    {
        this.kamera.GetComponent<Transform>().position = destinationSide;
        this.kamera.GetComponent<Transform>().rotation = rotationSide;
    }
    public void sideCamera2()
    {
        this.kamera.GetComponent<Transform>().position = destinationSide2;
        this.kamera.GetComponent<Transform>().rotation = rotationSide2;
    }
    public void backCamera()
    {
        this.kamera.GetComponent<Transform>().position = destinationBack;
        this.kamera.GetComponent<Transform>().rotation = rotationBack;
    }

}


