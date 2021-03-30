using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class ManipulateSizeByVoice : MonoBehaviour
{
    
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public void StartListening()
    {
        keywords.Add("größer", () =>
        {
            Debug.Log("größer");
            Vector3 newScale = transform.localScale;
            newScale *= 1.5f;
            transform.localScale = newScale;
        });

        //keywords.Add("rot", () =>
        //{
        //    Debug.Log("Farbe rot");
        //    GetComponent<ChangeColor>().TurnRed();
        //});

        //keywords.Add("blau", () =>
        //{
        //    Debug.Log("Farbe blau");
        //    GetComponent<ChangeColor>().TurnBlue();
        //});

        //keywords.Add("gelb", () =>
        //{
        //    Debug.Log("Farbe gelb");
        //    GetComponent<Renderer>().material.color = Color.yellow;
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
            keywordRecognizer.Dispose();
            Debug.Log("stopped listening");
        }

    }
}
