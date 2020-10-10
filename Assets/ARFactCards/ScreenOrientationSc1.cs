using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientationSc1 : MonoBehaviour
{
    // Start in landscape mode
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
