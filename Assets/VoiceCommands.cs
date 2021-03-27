using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceCommands : MonoBehaviour
{

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    public GameObject targetGameObject;

    // Start is called before the first frame update
    void Start()
    {
        //Create keywords for keyword recognizer
        keywords.Add("blue", () =>
        {
            Debug.Log("blue");
            targetGameObject.GetComponent<Renderer>().material.color = Color.blue;
        });

        keywords.Add("green", () =>
        {
            Debug.Log("green");
            targetGameObject.GetComponent<Renderer>().material.color = Color.green;
        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;

        keywordRecognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
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
