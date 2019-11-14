using UnityEngine;
using System.Collections;

public class CustomAxisSortCamera : MonoBehaviour 
{
    void Start()
    {
        var camera = GetComponent<Camera>();
        camera.transparencySortMode = TransparencySortMode.CustomAxis;
        camera.transparencySortAxis = new Vector3(0.0f, 0.5f, -0.25f);
    }
}