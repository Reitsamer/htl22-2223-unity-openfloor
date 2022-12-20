using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.GetBool("Attacking"))
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag.Equals("Player"))
            animator.SetBool("Attacking", true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Player"))
            animator.SetBool("Attacking", false);
    }
}
