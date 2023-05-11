using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]private float startingHealth;
     public float currentHealth{get; private set;}
     private Animator anim;
     private bool dead;

     [Header ("Conponents")]
     [SerializeField]private Behaviour[] components;

     private void Start(){
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
     }

     public void TakeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        currentHealth -= _damage;

        if(currentHealth > 0){
         anim.SetTrigger("hurt");
        }else{
         if(!dead){
            anim.SetTrigger("die");

            foreach(Behaviour component in components)
               component.enabled = false;

            dead = true;
         }
            
        }
     }

     private void Deactivate(){
      gameObject.SetActive(false);
     }

     public void AddHealth(float _value){
      currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
     }

     public void Respawn(){

      dead = false;
      AddHealth(startingHealth);
      anim.ResetTrigger("die");
      anim.Play("Idle");

      foreach(Behaviour component in components)
               component.enabled = true;
     }

     

}
