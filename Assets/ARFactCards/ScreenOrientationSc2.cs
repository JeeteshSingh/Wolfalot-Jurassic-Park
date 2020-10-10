using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientationSc2 : MonoBehaviour
{
    // Start in landscape mode
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
