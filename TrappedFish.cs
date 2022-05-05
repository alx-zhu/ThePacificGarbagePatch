using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public class TrappedFish : MonoBehaviour
{
    bool hasDied;
    
    //[SerializeField] Sprite deadSprite;
    [SerializeField] ParticleSystem pSystem;

    void OnCollisionEnter2D(Collision2D collision){

        if (ShouldDieFromCollision(collision)){
            //MUST say StartCoroutine if you use IENumerator
            StartCoroutine(Die());
            hasDied = true;
        }


    }

    bool ShouldDieFromCollision(Collision2D collision){
        if (hasDied){
            return false;
        }

        ScubaDiver scuba = collision.gameObject.GetComponent<ScubaDiver>();
        if (scuba != null){
            return true;
        } else {
            return false;
        }
        /*else if (collision.contacts[0].normal.y < -0.5) {
            //if something falls on top of the monster (-1 is coming straight down, 1 is going straight up, -0.5 is a 45 degree angle)
            return true;
        */
    }

    IEnumerator Die(){
        //GetComponent<SpriteRenderer>().sprite = deadSprite;
        pSystem.Play();
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
