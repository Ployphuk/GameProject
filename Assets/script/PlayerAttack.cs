using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private float attackCooldown;
    [SerializeField]private Transform firepoint;
    [SerializeField]private GameObject[] fireballs;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    
    private void Start(){
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update(){
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack(){
        anim.SetTrigger("Attack");
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firepoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball(){
        for(int i = 0; i< fireballs.Length; i++){
            if(fireballs[i].activeInHierarchy)
            return i;
        }
        return 0;
    }
}