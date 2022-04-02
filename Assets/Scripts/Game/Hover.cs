/**
 * Brandon Howe
 * Group Game Demo
 * Adds hover effects to powerups
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {
    public float speed;
    public float distance;
    public float offset;
    public bool timeUnscaled;
    public bool randomStart;
    public Vector3 dir = Vector3.up;

    private Vector3 startPos;
    private float randomOffset;

    void Start() {
        startPos = transform.localPosition;
        if (randomStart) {
            randomOffset = Random.Range(0f, speed);
        }
    }

    void Update() {
        if (timeUnscaled) {
            transform.localPosition = startPos + dir * Mathf.Sin(Time.unscaledTime * speed + offset + randomOffset) * distance;
        } else {
            transform.localPosition = startPos + dir * Mathf.Sin(Time.time * speed + offset + randomOffset) * distance;
        }
    }
}
