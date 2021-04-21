using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    private Animator m_animator;

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

