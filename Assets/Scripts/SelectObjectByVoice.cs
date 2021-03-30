using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;


public class SelectObjectByVoice : MonoBehaviour
{

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    //public GameObject targetGameObject;
    //public GameObject Object;
    //ChangeColor script;

    // Start is called before the first frame update
    void Start()
    {
        //script = GameObject.FindObjectOfType(typeof(ChangeColor)) as ChangeColor;
        //script.TurnGreen();
        //Create keywords for keyword recognizer
        keywords.Add("Würfel", () =>
        {
            Debug.Log("cube selected");
            GameObject target = GameObject.Find("Cube");
            target.GetComponent<ManipulateColorByVoice>().StartListening();
            //target.GetComponent<ManipulateSizeByVoice>().StartListening();
        });

        keywords.Add("Kugel", () =>
        {
            Debug.Log("sphere selected");
            GameObject target = GameObject.Find("Sphere");
            target.GetComponent<ManipulateColorByVoice>().StartListening();
            //target.GetComponent<ManipulateSizeByVoice>().StartListening();
        });

        keywords.Add("Zylinder", () =>
        {
            Debug.Log("cylinder selected");
            GameObject target = GameObject.Find("Cylinder");
            target.GetComponent<ManipulateColorByVoice>().StartListening();
        });

        keywords.Add("Kapsel", () =>
        {
            Debug.Log("Capsule selected");
            GameObject target = GameObject.Find("Capsule");
            target.GetComponent<ManipulateColorByVoice>().StartListening();
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
