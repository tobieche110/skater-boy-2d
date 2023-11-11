using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{   

    public float maxTime;
    private float time;

    public float maxHeightWall;
    public float minHeightWall;

    public float maxHeightShortWall;
    public float minHeightShortWall;

    public float carPos;

    public float groundGrindHeight;

    public float maxHeightSign;
    public float minHeightSign;

    public float maxHeightGrind;
    public float minHeightGrind;

    // Obstacles
    public GameObject wallPrefab;
    public GameObject shortWallPrefab;
    public GameObject carPrefab;

    // Grinds
    public GameObject groundGrindPrefab;
    public GameObject farmaciaPrefab;
    public GameObject pizzeriaPrefab;
    public GameObject roofPrefab;

    GameObject wall;
    GameObject groundGrind;

    // Start is called before the first frame update
    void Start()
    {
        time = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(time > maxTime){

            int randomChoice = Random.Range(0, 7);

            if(randomChoice == 0) {
                // Elige una pared
                GameObject wall =  Instantiate(wallPrefab);
                wall.transform.position = transform.position + new Vector3(0, Random.Range(minHeightWall, maxHeightWall), 0);

            } else if (randomChoice == 1) {
                // Elige un grind en el piso
                GameObject groundGrind = Instantiate(groundGrindPrefab);
                groundGrind.transform.position = transform.position + new Vector3(0, groundGrindHeight, 0);

            } else if (randomChoice == 2) {
                // Elige un cartel de pizzeria
                GameObject pizzeriaGrind = Instantiate(pizzeriaPrefab);
                pizzeriaGrind.transform.position = transform.position + new Vector3(0, Random.Range(minHeightSign, maxHeightSign), 0);

            } else if (randomChoice == 3) {
                // Elige un cartel de farmacia
                GameObject farmaciaGrind = Instantiate(farmaciaPrefab);
                farmaciaGrind.transform.position = transform.position + new Vector3(0, Random.Range(minHeightSign, maxHeightSign), 0);

            } else if (randomChoice == 4) {
                // Elige un techo
                GameObject roofGrind = Instantiate(roofPrefab);
                roofGrind.transform.position = transform.position + new Vector3(0, Random.Range(minHeightSign, maxHeightSign), 0);

            } else if(randomChoice == 5) {
                // Elige una pared baja
                GameObject shortWall =  Instantiate(shortWallPrefab);
                shortWall.transform.position = transform.position + new Vector3(0, Random.Range(minHeightShortWall, maxHeightShortWall), 0);
                
            } else if(randomChoice == 6) {
                // Elige un auto
                GameObject car =  Instantiate(carPrefab);
                car.transform.position = transform.position + new Vector3(0, carPos, 0);
            }

            time = 0;
        }

        time += Time.deltaTime;
        Destroy(wall, 8f);
    }
}
