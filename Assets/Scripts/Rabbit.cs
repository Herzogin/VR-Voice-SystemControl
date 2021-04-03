using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    //private string[] m_buttonNames = new string[] { "Idle", "Run", "Dead" };

    private Animator m_animator;

    // Use this for initialization
    //void Start()
    //{

    //    //m_animator = GetComponent<Animator>();
    //    run();

    //}

   public void run()
    {
        m_animator = GetComponent<Animator>();
        m_animator.SetInteger("AnimIndex", 1);
        m_animator.SetTrigger("Next");
    }

    public void idle()
    {
        m_animator = GetComponent<Animator>();
        m_animator.SetInteger("AnimIndex", 0);
        m_animator.SetTrigger("Next");
    }
}

