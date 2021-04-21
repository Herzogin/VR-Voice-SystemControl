using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;


public class ManipulateColorByVoice : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    
    public void StartListening()
    {
        keywords.Add("grün", () =>
        {
            Debug.Log("grün");
            GetComponent<ChangeColor>().TurnGreen();          
        });

        keywords.Add("rot", () =>
        {
            Debug.Log("Farbe rot");
            GetComponent<ChangeColor>().TurnRed();            
        });

        keywords.Add("blau", () =>
        {
            Debug.Log("Farbe blau");
            GetComponent<ChangeColor>().TurnBlue();           
        });

        keywords.Add("gelb", () =>
        {
            Debug.Log("Farbe gelb");
            GetComponent<Renderer>().material.color = Color.yellow;
        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;

        keywordRecognizer.Start();
    }

    


    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
            keywordRecognizer.Dispose();
            Debug.Log("stopped listening");
        }

    }
}
