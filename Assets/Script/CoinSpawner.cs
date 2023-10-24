using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float maxTime;
    private float time;

    public float maxHeight;
    public float minHeight;

    public GameObject CoinPrefab;
    GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        time = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(time > maxTime){
            GameObject coin =  Instantiate(CoinPrefab);
            coin.transform.position = transform.position + new Vector3(0, Random.Range(minHeight, maxHeight), 0);
            time = 0;
        }

        time += Time.deltaTime;
        Destroy(coin, 8f);
    }
}
