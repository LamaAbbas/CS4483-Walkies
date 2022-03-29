/**
 *      Lama Abbas - 251035313
 *      Individual Game Prototype
 *      Generate Level class that handles random generation of new sections
 *      * Does not remove older sections, this would be implemented by a queue
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour {

    // Array of sections that are to be selected from
    public GameObject[] section;
    public GameObject[] powerUps;
    // The initial position the first section would be on
    [SerializeField] private float zPos = 281.8694f;
    [SerializeField] private int secNum;
    private bool creatingSection = false;
    GameObject newSection;

    // Using coroutines to control the frequency of section instantiation
    private void Update() {
        if (!creatingSection) {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection() {
        secNum = Random.Range(0, 4);
        newSection = Instantiate(section[secNum], new Vector3(15.7001f, -261.4271f, zPos), Quaternion.identity);
        
        secNum = (int)Random.Range(0, 2);
        if(secNum <= 2){
            Transform spawn = newSection.transform.Find("PowerUpSpawners").GetChild((int)Random.Range(0, 2));
            Instantiate(powerUps[secNum], new Vector3(spawn.position.x, spawn.position.y, spawn.position.z), Quaternion.identity);
        } // end if

        zPos += 50;
        yield return new WaitForSeconds(5);
        creatingSection = false;
    }
}
