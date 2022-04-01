/**
 * Khaleel Abdool Mohammed
 * Group Game Demo
 * Child class for points power-up
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Points : PowerUp {
    public float powerUpTime = 7;
    GameObject target;
    override
    public void ActivatePowerup(GameObject dog){
        target = GameObject.Find("Canvas");
        StartCoroutine("PointModification");
    } // end method

    IEnumerator PointModification(){
        target.GetComponent<GameMenuManager>().scoreModifier = 3;
        yield return new WaitForSeconds(powerUpTime);
        target.GetComponent<GameMenuManager>().scoreModifier = 1;
        Destroy(this.gameObject);
    } // end method

} // end class
