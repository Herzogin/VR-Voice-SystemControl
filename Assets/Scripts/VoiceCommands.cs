using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceCommands : MonoBehaviour
{

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    GameObject sceneManager;
    //public GameObject turtle;
    //TurtleMove TurtleScript;
    public GameObject kamera;
    SkyboxController skyboxScript;
    public GameObject[] rabbits;


    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");
        //TurtleScript = GameObject.FindObjectOfType(typeof(TurtleMove)) as TurtleMove;
        skyboxScript = GameObject.FindObjectOfType(typeof(SkyboxController)) as SkyboxController;

        //Create keywords for keyword recognizer
        keywords.Add("Anfang", () =>
        {
            Debug.Log("Anfang");
            FindObjectOfType<AudioManager>().PlayAudio("SceneSwitchSound");
            sceneManager.GetComponent<SceneSwitch>().switchToScene("EntranceScene");
        });

        keywords.Add("Strand", () =>
        {
            Debug.Log("Strand");
            FindObjectOfType<AudioManager>().PlayAudio("SceneSwitchSound");
            sceneManager.GetComponent<SceneSwitch>().switchToScene("Scene1Beach");
        });

        keywords.Add("Wald", () =>
        {
            Debug.Log("Wald");
            FindObjectOfType<AudioManager>().PlayAudio("SceneSwitchSound");
            sceneManager.GetComponent<SceneSwitch>().switchToScene("Scene2Forest");
        });

        keywords.Add("Hilfe an", () =>
        {
            Debug.Log("Hilfe an");
            FindObjectOfType<AudioManager>().PlayAudio("HelpOnSound");
            GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = true;
        });

        keywords.Add("Hilfe aus", () =>
        {
            Debug.Log("Hilfe aus");
            FindObjectOfType<AudioManager>().PlayAudio("HelpOffSound");
            GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = false;
        });

        keywords.Add("Musik an", () =>
        {
            Debug.Log("Musik an");
            //FindObjectOfType<AudioManager>().UnPauseAudio("JoshuasSong");
            FindObjectOfType<AudioManager>().UnPauseAudio("BackgroundSound");
        });

        keywords.Add("Musik aus", () =>
        {
            Debug.Log("Musik aus");
            //FindObjectOfType<AudioManager>().PauseAudio("JoshuasSong");
            FindObjectOfType<AudioManager>().PauseAudio("BackgroundSound");

        });
        //keywords.Add("lauter", () =>
        //{
        //    Debug.Log("lauter");
        //    FindObjectOfType<AudioManager>().Volume("HelpOffSound");
        //    FindObjectOfType<AudioManager>().Volume("HelpOnSound");
        //});

        keywords.Add("Stop", () =>
        {
            Debug.Log("Stop");
            GameObject.Find("Butterfly").GetComponent<Animation>().enabled = false;
            //GameObject.Find("Rabbit").GetComponent<Animator>().enabled = false;
            rabbits = GameObject.FindGameObjectsWithTag("animal");
            foreach (GameObject rabbit in rabbits)
            {
                rabbit.GetComponent<Animator>().enabled = false;
            }
            //FindObjectOfType<AudioManager>().PauseAudio("JoshuasSong");
            FindObjectOfType<AudioManager>().PauseAudio("BackgroundSound");
        });

        keywords.Add("Start", () =>
        {
            Debug.Log("Start");
            GameObject.Find("Butterfly").GetComponent<Animation>().enabled = true;
            //GameObject.Find("Rabbit").GetComponent<Animator>().enabled = true;
            rabbits = GameObject.FindGameObjectsWithTag("animal");
            foreach (GameObject rabbit in rabbits)
            {
                rabbit.GetComponent<Animator>().enabled = true;
            }
            //FindObjectOfType<AudioManager>().UnPauseAudio("JoshuasSong");
            FindObjectOfType<AudioManager>().UnPauseAudio("BackgroundSound");
        });

        keywords.Add("Tag", () =>
        {
            Debug.Log("Tag");
            skyboxScript.SkyToDay();
        });

        keywords.Add("Nacht", () =>
        {
            Debug.Log("Nacht");
            skyboxScript.SkyToNight();
        });

        //keywords.Add("Schildkröte", () =>
        //{
        //    Debug.Log("Schildkröte");
        //    TurtleScript.TurtleWalk();
        //});





        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;

        keywordRecognizer.Start();
    }

 
    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}
