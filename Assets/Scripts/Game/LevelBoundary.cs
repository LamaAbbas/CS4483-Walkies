/**
 *      Lama Abbas - 251035313
 *      Individual Game Prototype
 *      Level Bounday class that serves as extra boundary precaution so that the dogs cannot be controlled off-screen
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour {

    public static float leftSide = -7.1f;
    public static float rightSide = 6.9f;
    public float internalLeft;
    public float internalRight;

    private void Update() {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
