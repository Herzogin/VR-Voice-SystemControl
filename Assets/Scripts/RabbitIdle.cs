using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitIdle : MonoBehaviour
{
    private Animator m_animator;
    

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_animator.SetInteger("AnimIndex", 0);
        m_animator.SetTrigger("Next");
    }
}
