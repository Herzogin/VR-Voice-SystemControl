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

    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");

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
