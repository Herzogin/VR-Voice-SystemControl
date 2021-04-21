
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
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    GameObject targetGameObject;



    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    void Start()
    {
        targetGameObject = null;
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

        keywords.Add("magenta", () =>
        {
            Debug.Log("magenta");
            targetGameObject.GetComponent<Renderer>().material.color = Color.magenta;
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
        targetGameObject = e.target.gameObject;
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        targetGameObject = null;
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}