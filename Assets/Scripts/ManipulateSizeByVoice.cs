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
