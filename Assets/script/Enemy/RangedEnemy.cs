using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField]private float attackCollDown;
    [SerializeField]private float range;
    
    [SerializeField]private int damage;

    [Header("Ranged Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;


    [Header("Collider Parameters")]
    [SerializeField]private BoxCollider2D boxCollider;
    [SerializeField]private float colliderDistance;


     [Header("Player Layers")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    
    private Animator anim;
    private EnemyPatrol enemyPatrol;


     void Start()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(PlayerInsight()){
            if(cooldownTimer >= attackCollDown){
                cooldownTimer = 0;
                anim.SetTrigger("rangedAttack");
            }
        }

        if(enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInsight();
    }

    private void RangedAttack(){
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firepoint.position;
        fireballs[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();

    }

    private int FindFireball(){
        for(int i = 0; i < fireballs.Length; i++){
            if(!fireballs[i].activeInHierarchy)
            return i;
        }
        return 0;
    }

     private bool PlayerInsight(){
         RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
