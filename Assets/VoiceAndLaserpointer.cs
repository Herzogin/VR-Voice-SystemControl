
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceAndLaserpointer : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    Color oldcolor;
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    public GameObject egal;
    GameObject targetGameObject;



    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    void Start()
    {
        targetGameObject = egal;
        //keywords for keyword recognizer
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

        keywords.Add("yellow", () =>
        {
            Debug.Log("yellow");
            targetGameObject.GetComponent<Renderer>().material.color = Color.yellow;
        });

        keywords.Add("red", () =>
        {
            Debug.Log("red");
            targetGameObject.GetComponent<Renderer>().material.color = Color.red;
        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;

        keywordRecognizer.Start();
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        targetGameObject = e.target.gameObject;
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        oldcolor = e.target.gameObject.GetComponent<Renderer>().material.color;
        e.target.gameObject.GetComponent<Renderer>().material.color = Color.white;
        targetGameObject = e.target.gameObject;
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        e.target.gameObject.GetComponent<Renderer>().material.color =oldcolor;
        targetGameObject = egal;
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