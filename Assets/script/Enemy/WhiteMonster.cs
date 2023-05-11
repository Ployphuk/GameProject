using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMonster : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField]private float attackCollDown;
    [SerializeField]private float range;
    
    [SerializeField]private int damage;

    [Header("Collider Parameters")]
    [SerializeField]private BoxCollider2D boxCollider;
    [SerializeField]private float colliderDistance;

    [Header("Player Layers")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;

    private Health playerHealth;

    private EnemyPatrol enemyPatrol;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(PlayerInsight()){
            if(cooldownTimer >= attackCollDown){
                cooldownTimer = 0;
                anim.SetTrigger("Attack");
            }
        }

        if(enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInsight();
    }

    private bool PlayerInsight(){
         RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if(hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer(){
        if(PlayerInsight()){
            playerHealth.TakeDamage(damage);
        }
    }
}
