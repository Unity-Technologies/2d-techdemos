using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CustomAxisSortCamera : MonoBehaviour 
{
    void Start()
    {
        var camera = GetComponent<Camera>();
        camera.transparencySortMode = TransparencySortMode.CustomAxis;
        camera.transparencySortAxis = new Vector3(0.0f, 0.5f, -0.25f);

        // Use QualitySettings to change Render Pipeline asset
        var i = 0;
        for (; i < QualitySettings.names.Length; ++i)
        {
            if (QualitySettings.names[i] == "CustomAxisSort")
                break;
        }
        QualitySettings.SetQualityLevel(i);
    }
}