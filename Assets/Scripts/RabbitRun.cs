using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitRun : MonoBehaviour
{
    private Animator m_animator;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_animator.SetInteger("AnimIndex", 1);
        m_animator.SetTrigger("Next");
    }
}
