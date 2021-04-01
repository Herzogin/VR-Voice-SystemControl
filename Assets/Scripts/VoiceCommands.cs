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
            sceneManager.GetComponent<SceneSwitch>().switchToScene("EntranceScene");
        });

        keywords.Add("Strand", () =>
        {
            Debug.Log("Strand");
            sceneManager.GetComponent<SceneSwitch>().switchToScene("Scene1Beach");
        });

        keywords.Add("Wald", () =>
        {
            Debug.Log("Wald");
            sceneManager.GetComponent<SceneSwitch>().switchToScene("Scene2Forest");
        });

        keywords.Add("Hilfe an", () =>
        {
            Debug.Log("Hilfe an");
            GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = true;
        });

        keywords.Add("Hilfe aus", () =>
        {
            Debug.Log("Hilfe aus");
            GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = false;
        });

        keywords.Add("Stop", () =>
        {
            Debug.Log("Stop");
            GameObject.Find("Butterfly").GetComponent<Animation>().enabled = false;
        });

        keywords.Add("Start", () =>
        {
            Debug.Log("Start");
            GameObject.Find("Butterfly").GetComponent<Animation>().enabled = true;
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
