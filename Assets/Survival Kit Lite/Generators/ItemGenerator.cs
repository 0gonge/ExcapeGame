using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject knifePrefab;
    public GameObject ropePrefab;
    public GameObject waterPrefab;

    float span = 1.0f;
    float delta = 0;
    int knifeRatio = 2;  
    int ropeRatio = 2;
    int waterRatio = 2;
    int totalRatio;  

    void Start()
    {
        totalRatio = knifeRatio + ropeRatio + waterRatio + 6;  
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, totalRatio + 1); 

            if (dice <= this.knifeRatio)
            {
                item = Instantiate(knifePrefab) as GameObject;
            }
            else if (dice <= this.knifeRatio + this.ropeRatio)
            {
                item = Instantiate(ropePrefab) as GameObject;
            }
            else if (dice <= this.knifeRatio + this.ropeRatio + this.waterRatio)
            {
                item = Instantiate(waterPrefab) as GameObject;
            }
            else
            {
                item = Instantiate(applePrefab) as GameObject;
            }

            float x = Random.Range(-1, 5);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
        }
    }
}
