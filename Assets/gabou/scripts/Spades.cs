using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spades : MonoBehaviour
{
    public StageManager stage;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider && collider.tag.Contains("Player"))
        {
            stage.lost = true;
            animator.SetBool("blood", true);
        }
    }
}
