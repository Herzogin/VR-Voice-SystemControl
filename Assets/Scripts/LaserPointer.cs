using UnityEngine;
using Valve.VR.Extras;

public class LaserPointer : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    GameObject sceneManager;
    SkyboxController skyboxScript;
    GameObject[] rabbits;



    void Awake()
    {
        //laserPointer.PointerIn += PointerInside;
        //laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    private void Start()
    {
        sceneManager = GameObject.Find("SceneManager");
        skyboxScript = GameObject.FindObjectOfType(typeof(SkyboxController)) as SkyboxController;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        Debug.Log("clicked");

        if (e.target.name == "islandScene")
        {
            Debug.Log(e.target.name + " was clicked");
            FindObjectOfType<AudioManager>().PlayAudio("SceneSwitchSound");
            sceneManager.GetComponent<SceneSwitch>().switchToScene("Scene1Beach");
        } 
        if (e.target.name == "forestScene")
        {
            Debug.Log(e.target.name + " was clicked");
            FindObjectOfType<AudioManager>().PlayAudio("SceneSwitchSound");
            sceneManager.GetComponent<SceneSwitch>().switchToScene("Scene2Forest");
        }
        if (e.target.name == "sunSwitch")
        {
            Debug.Log(e.target.name + " was clicked");
            skyboxScript.SkyToDay();
        }
        if (e.target.name == "MusicOn")
        {
            Debug.Log(e.target.name + " was clicked");
            FindObjectOfType<AudioManager>().UnPauseAudio("BackgroundSound");
        }
        if (e.target.name == "MusicOff")
        {
            Debug.Log(e.target.name + " was clicked");
            FindObjectOfType<AudioManager>().PauseAudio("BackgroundSound");
        }
        if (e.target.name == "moonSwitch")
        {
            Debug.Log(e.target.name + " was clicked");
            skyboxScript.SkyToNight();
        }
        if (e.target.name == "getHelp")
        {
            Debug.Log(e.target.name + " was clicked");
            GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = true;
        }
        if (e.target.name == "getHelpOff")
        {
            Debug.Log(e.target.name + " was clicked");
            GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = false;
        }
        if (e.target.name == "Stop")
        {
            Debug.Log(e.target.name + " was clicked");
            rabbits = GameObject.FindGameObjectsWithTag("animal");
            foreach (GameObject rabbit in rabbits)
            {
                rabbit.GetComponent<Animator>().enabled = false;
            }
            GameObject.Find("Butterfly").GetComponent<Animation>().enabled = false;
            FindObjectOfType<AudioManager>().UnPauseAudio("BackgroundSound");
        }
        if (e.target.name == "Play")
        {
            Debug.Log(e.target.name + " was clicked");
            rabbits = GameObject.FindGameObjectsWithTag("animal");
            foreach (GameObject rabbit in rabbits)
            {
                rabbit.GetComponent<Animator>().enabled = true;
            }
            GameObject.Find("Butterfly").GetComponent<Animation>().enabled = true;
            FindObjectOfType<AudioManager>().UnPauseAudio("BackgroundSound");
        }
        else
        {
            Debug.Log(e.target.name + " was clicked, but we ignored it");
        }
     
    }
}