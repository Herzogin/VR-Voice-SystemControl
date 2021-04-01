using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{

    public Material daySky;
    public Material nightSky;


    public void SkyToDay()
    {
        RenderSettings.skybox = daySky;
    }

    public void SkyToNight()
    {
        RenderSettings.skybox = nightSky;
    }
}
