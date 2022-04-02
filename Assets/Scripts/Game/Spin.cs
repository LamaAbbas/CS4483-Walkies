/**
 * Brandon Howe
 * Group Game Demo
 * Adds spin effects to the power-ups
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spin : MonoBehaviour {
    public Vector3 direction;
    public bool randomInvert;

    void Start() {
        if (randomInvert) {
            if (Random.Range(0, 2) == 0) {
                direction *= -1;
            }
        }
    }

    void Update() {
        transform.Rotate(direction * Time.deltaTime);
    }
}
