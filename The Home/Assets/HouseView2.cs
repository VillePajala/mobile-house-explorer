using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HouseView2 : MonoBehaviour
{
    // Pinch zoomin muuttujat jääkööt tänne, vaikka lopulta päätinkin olla käyttämättä koko toimintoa
    public float perspectiveZoomSpeed = 0.5f;
    public float orthoZoomSpeed = 0.5f;

    private GameObject kamera = null;

    void Start()
    {
        this.kamera = GameObject.Find("Camera");
    }

    
    void Update()
    {
        // Kosketus
        if (Input.touchCount > 0) // Jos kosketaan
        {
            // Paljonko kosketuspaikka muuttunut x- ja y-akseleiden suhteen
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Jos yksi sormi, niin kierretään kameraan ja liikutaan eteenpäin
            if (Input.touchCount == 1)
            {
                // Valitaan se suunta (vaaka/pysty), johon on liikutettu sormea enemmän
                // Jos liikutettu vaakasuunnassa enemmän, kierretään kameraa
                if (Mathf.Abs(touchDeltaPosition.x) > Mathf.Abs(touchDeltaPosition.y))
                {
                    // Kummalla puolella
                    if (touchDeltaPosition.x > 0.0f)
                    {
                        this.kamera.GetComponent<Transform>().Rotate(0f, 50f * Time.deltaTime, 0f);
                    }
                    else if (touchDeltaPosition.x < 0.0f)
                    {
                        this.kamera.GetComponent<Transform>().Rotate(0f, -50f * Time.deltaTime, 0f);
                    }
                }

                // Jos taas liikutettu pystysuunnassa enemmän mennään eteen/taakse
                if (Mathf.Abs(touchDeltaPosition.y) >= Mathf.Abs(touchDeltaPosition.x))
                {
                    if (touchDeltaPosition.y > 0.0f)
                    {
                        this.kamera.GetComponent<Transform>().Translate(0f, 0f, 5f * Time.deltaTime);
                    }
                    else if (touchDeltaPosition.y < 0.0f)
                    {
                        this.kamera.GetComponent<Transform>().Translate(0f, 0f, -5f * Time.deltaTime);
                    }
                }
            }

            // Jos kaksi sormea
            if (Input.touchCount == 2)
            { 
                // Mikäli kahdella sormella liikutetaan vasemmalle / oikealle, kamera liikkuu sivusuunnassa
                if (Mathf.Abs(touchDeltaPosition.x) > Mathf.Abs(touchDeltaPosition.y))
                {
                    if (touchDeltaPosition.x > 0.0f)
                    {
                        this.kamera.GetComponent<Transform>().Translate(-0.05f, 0f, 0f * Time.deltaTime);
                    }
                    else if (touchDeltaPosition.x < 0.0f)
                    {
                        this.kamera.GetComponent<Transform>().Translate(0.05f, 0f, 0f * Time.deltaTime);
                    }
                }

                // Jos taas liikutettu pystysuunnassa enemmän mennään ylös / alas
                if (Mathf.Abs(touchDeltaPosition.y) >= Mathf.Abs(touchDeltaPosition.x))
                {
                    if (touchDeltaPosition.y > 0.0f)
                    {
                        this.kamera.GetComponent<Transform>().Translate(0f, -0.1f, 0f * Time.deltaTime);
                    }
                    else if (touchDeltaPosition.y < 0.0f)
                    {
                        this.kamera.GetComponent<Transform>().Translate(0f, 0.1f, 0f * Time.deltaTime);
                    }
                }
            }

            // Jos kolme sormea
            if (Input.touchCount == 3)
            {
                // Kolmella sormella voidaan kääntää kameraa ylös ja alas
                if (touchDeltaPosition.y > 0.0f)
                {
                    this.kamera.GetComponent<Transform>().Rotate(-1f, 0f * Time.deltaTime, 0f);
                }
                else if (touchDeltaPosition.y < 0.0f)
                {
                    this.kamera.GetComponent<Transform>().Rotate(1f, 0f * Time.deltaTime, 0f);
                }
            }
        }
    }
}








