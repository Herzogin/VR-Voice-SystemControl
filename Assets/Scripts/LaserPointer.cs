﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class LaserPointer : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    GameObject sceneManager;



    void Awake()
    {
        //laserPointer.PointerIn += PointerInside;
        //laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    private void Start()
    {
        sceneManager = GameObject.Find("SceneManager");
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        Debug.Log("clicked");

        if (e.target.name == "islandScene")
        {
            Debug.Log(e.target.name + " was clicked");
            FindObjectOfType<AudioManager>().PlayAudio("SceneSwitchSound");
            sceneManager.GetComponent<SceneSwitch>().switchToScene("Scene1Beach");
        } 
        if (e.target.name == "forestScene")
        {
            Debug.Log(e.target.name + " was clicked");
            FindObjectOfType<AudioManager>().PlayAudio("SceneSwitchSound");
            sceneManager.GetComponent<SceneSwitch>().switchToScene("Scene2Forest");
        }
        else
        {
            Debug.Log(e.target.name + " was clicked, but we ignored it");
            // Destroy(e.target.gameObject);
        }
        //Vector3 pos = e.target.position;
        //pos.y += 1;
        //e.target.position = pos;
        //Debug.Log(e.target.ToString());
        // klappt nicht: 

    }

    //public void PointerInside(object sender, PointerEventArgs e)
    //{
        //if (e.target.name == "Cube" || e.target.name == "Sphere" || e.target.name == "GOBLIN" || e.target.name == "Oak_Tree" || e.target.name == "Fir_Tree" || e.target.name == "Fir_Tree2" || e.target.name == "Fir_Tree3")
        //{
        //    oldcolor = e.target.gameObject.GetComponent<Renderer>().material.color;
        //    e.target.gameObject.GetComponent<Renderer>().material.color = Color.green;
        //}

        //if (e.target.name == "Cube")
        //{
        //    Debug.Log("Cube was entered");
        //}
        //else if (e.target.name == "Sphere")
        //{
        //    Debug.Log("Sphere was entered");
        //}
    //}

   //public void PointerOutside(object sender, PointerEventArgs e)
    //{
        //if (e.target.name == "Cube" || e.target.name == "Sphere" || e.target.name == "GOBLIN" || e.target.name == "Oak_Tree" || e.target.name == "Fir_Tree" || e.target.name == "Fir_Tree2" || e.target.name == "Fir_Tree3")
        //{
        //    e.target.gameObject.GetComponent<Renderer>().material.color = oldcolor;
        //}

        //if (e.target.name == "Cube")
        //{
        //    Debug.Log("Cube was exited");
        //}
        //else if (e.target.name == "Sphere")
        //{
        //    Debug.Log("Sphere was exited");
        //}
    //}


    //IEnumerator waiter(PointerEventArgs e)
    //{
    //    Vector3 pups = new Vector3(0.01f, 0.01f, 0.01f);
    //    float xsize = e.target.localScale.x;
    //    //Debug.Log("waiter active");
    //    while (xsize > 0.02f)
    //    {
    //        xsize = e.target.localScale.x;
    //        e.target.localScale = e.target.localScale - pups;
    //        yield return new WaitForSeconds(0.0001f);
    //        //Debug.Log("xsize:" + xsize);

    //    }
    //    Destroy(e.target.gameObject);
    //}
}