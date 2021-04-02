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
            //FindObjectOfType<AudioManager>().PlayAudio("BackgroundSound");
            FindObjectOfType<AudioManager>().UnPauseAudio("JoshuasSong");
        });

        keywords.Add("Musik aus", () =>
        {
            Debug.Log("Musik aus");
            FindObjectOfType<AudioManager>().PauseAudio("JoshuasSong");

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
            FindObjectOfType<AudioManager>().PauseAudio("JoshuasSong");
        });

        keywords.Add("Start", () =>
        {
            Debug.Log("Start");
            GameObject.Find("Butterfly").GetComponent<Animation>().enabled = true;
            FindObjectOfType<AudioManager>().UnPauseAudio("JoshuasSong");
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
