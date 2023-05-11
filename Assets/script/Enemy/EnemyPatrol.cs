using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField]private Transform leftEdge;
    [SerializeField]private Transform rightEdge;


    [Header ("Enemy")]
    [SerializeField]private Transform enemy;


    [Header ("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField]private float idleDuration;
    private float idleTimer;


    [Header("Enemy Animator")]
    [SerializeField]private Animator anim;


     // Start is called before the first frame update
    void Start()
    {
        initScale = enemy.localScale;
    }


    private void MoveInDerection(int _direction){

        idleTimer = 0;
        anim.SetBool("Moving", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
   

    private void OnDisable(){
        anim.SetBool("Moving", false);
    } 
    // Update is called once per frame
    void Update()
    {
        if(movingLeft){
            if(enemy.position.x >= leftEdge.position.x)
            MoveInDerection(-1);
            else{
                DirectionChange();
            }
        }else{
            if(enemy.position.x <= leftEdge.position.x)
            MoveInDerection(1);

            else{
                DirectionChange();
            }
        }
        
    }

    private void DirectionChange(){
        anim.SetBool("Moving", false);

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
        movingLeft = ! movingLeft;
    }
}
