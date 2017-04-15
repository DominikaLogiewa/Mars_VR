using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Sphere;
    public Transform CameraTransform;
    public Transform SphereTransform;
    public float movementForward;
    public float movementSideways;
    public float cameraMovementSpeed, cameraRotationSpeed;
    //wyznaczony, na oko bez okularow, metoda prob i bledow, wzgledny srodek krzywego ekranu 
    Vector3 rotation, previousMousePosition = new Vector3(300, 300, 300);
    // Use this for initialization
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
        Sphere = MainCamera = GameObject.Find("Sphere");


    }
    void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        CameraTransform = Sphere.transform;
        if (Input.GetKey(KeyCode.W))
        {
            SphereTransform.transform.Translate(new Vector3(0, 0, cameraMovementSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            SphereTransform.transform.Translate(new Vector3(0, 0, -cameraMovementSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            SphereTransform.transform.Translate(new Vector3(-cameraMovementSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            SphereTransform.transform.Translate(new Vector3(cameraMovementSpeed * Time.deltaTime, 0, 0));
        }
        //ujemna wartosc bo inaczej odwracalo w stone przeciwna do ruchu myszka 
      
            rotation = -(previousMousePosition - Input.mousePosition);
        SphereTransform.transform.Rotate(0, Time.deltaTime * cameraRotationSpeed * rotation.x, 0);

            //na koniec cudow przypisz previousMousePosition wartosc obecnej
            previousMousePosition = Input.mousePosition;

    }
}
