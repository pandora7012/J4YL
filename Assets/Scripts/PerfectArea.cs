using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectArea : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" && Player.posOfCol != 5)
        {
            animator.SetTrigger("Perfect");
            Player.score++;
        }
    }
}
