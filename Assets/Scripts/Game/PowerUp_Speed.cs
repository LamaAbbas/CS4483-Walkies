using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : PowerUp
{   
    public float powerUpTime = 5;
    GameObject target;
    override
    public void ActivatePowerup(GameObject dog){
        target = dog;
        StartCoroutine("LowerSpeed");
    } // end method

    IEnumerator LowerSpeed(){
        target.GetComponent<Dog>().setSpeed(10f);
        yield return new WaitForSeconds(powerUpTime);
        target.GetComponent<Dog>().setSpeed(5f);
        Destroy(this.gameObject);
    } // end method
} // end method


