/**
 * Khaleel Abdool Mohammed
 * Group Game Demo
 * Child class for shield power-up
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class PowerUp_Shield : PowerUp {
    override
    public void ActivatePowerup(GameObject dog){
        dog.GetComponent<Dog>().hasShield = true;
        dog.transform.GetChild(0).GetChild(1).Find("Shield").gameObject.GetComponent<MeshRenderer>().enabled = true;
        Destroy(this.gameObject); // destroy
    } // end method
} // end method
