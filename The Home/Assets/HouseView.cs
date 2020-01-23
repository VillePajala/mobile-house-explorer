using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HouseView : MonoBehaviour
{
    // Pinch Zoom / Nopeudet
    public float perspectiveZoomSpeed = 0.5f;
    public float orthoZoomSpeed = 0.5f;

    private GameObject kamera = null;

    void Start()
    {
        this.kamera = GameObject.Find("Camera");
    }

    // Update is called once per frame
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
                        this.kamera.GetComponent<Transform>().Translate(0f, 0f, 6f * Time.deltaTime);
                    }
                    else if (touchDeltaPosition.y < 0.0f)
                    {
                        this.kamera.GetComponent<Transform>().Translate(0f, 0f, -6f * Time.deltaTime);
                    }
                }
            }

            // Pinch Zoom
            // Jos kaksi sormea, niin zoomataan
            if (Input.touchCount == 2)
            {
                // Tallennetaan kummankin sormen kosketus
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                // Katsotaan siirtmät edeliseen tilanteeseen nähden
                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                // Määritellään zoomauksen suuruus
                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                // Jos ortographi -kamera, niin zoomaillaan 2D:nä kameran size -ominaisuudella
                if (this.kamera.GetComponent<Camera>().orthographic)
                {
                    this.kamera.GetComponent<Camera>().orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                    // Huolehditaan, ettei zoomaus mene nollaksi ja pysyy halutulla alueella
                    this.kamera.GetComponent<Camera>().orthographicSize = Mathf.Max(this.kamera.GetComponent<Camera>().orthographicSize, 0.1f);
                }
                else
                {
                    // Jos perspektiivi -kamera, niin zoomataan muuttamalla Field of View -arvoa
                    this.kamera.GetComponent<Camera>().fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                    // Huolehditaan, että pysyy annetulla alueella
                    this.kamera.GetComponent<Camera>().fieldOfView = Mathf.Clamp(this.kamera.GetComponent<Camera>().fieldOfView, 0.1f, 179.9f);
                }
            }
        }
    }
}
