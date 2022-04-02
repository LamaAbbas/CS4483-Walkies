using System.Collections;
/**
 * Khaleel Abdool Mohammed
 * Group Game Demo
 * Child class for speed power-up
 */
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : PowerUp {

    public bool activate = false;
    public float powerUpTime = 5;
    GameObject target;
    override
    public void ActivatePowerup(GameObject dog){
        target = dog;
        if (!activate) {
            activate = true;
            StartCoroutine("LowerSpeed");
        }
        
    } // end method

    // This will need to be fixed accordingly for horizontal and vertical speeds
    IEnumerator LowerSpeed(){
        target.GetComponent<Dog>().setSpeed(40f);
        yield return new WaitForSeconds(powerUpTime);
        target.GetComponent<Dog>().setSpeed(-40f);
        activate = false;
        Destroy(this.gameObject);
    } // end method
} // end method


