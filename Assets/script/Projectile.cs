using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private bool Speed;
    private bool hit;


    private BoxCollider2D boxCollider2D;
    private Animator anim;

    private void Awake(){
        boxCollider2D = GetComponent<BoxCollider2D>();
        
    }
}
