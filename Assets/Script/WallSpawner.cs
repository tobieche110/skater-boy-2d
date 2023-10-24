using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{   

    public float maxTime;
    private float time;

    public float maxHeightWall;
    public float minHeightWall;
    public float maxHeightGrind;
    public float minHeightGrind;

    public GameObject wallPrefab;
    public GameObject grindPrefab;
    GameObject wall;
    GameObject grind;

    // Start is called before the first frame update
    void Start()
    {
        time = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(time > maxTime){

            int randomChoice = Random.Range(0, 2);

            if(randomChoice == 0) {
                // Elige una pared
                GameObject wall =  Instantiate(wallPrefab);
                wall.transform.position = transform.position + new Vector3(0, Random.Range(minHeightWall, maxHeightWall), 0);
            } else {
                // O elige un grind
                GameObject grind = Instantiate(grindPrefab);
                grind.transform.position = transform.position + new Vector3(0, Random.Range(minHeightGrind, maxHeightGrind), 0);
            }

            time = 0;
        }

        time += Time.deltaTime;
        Destroy(wall, 8f);
    }
}
