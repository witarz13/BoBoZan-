using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeDisplay : MonoBehaviour
{
    
    public Zan GetZan;
    public GameObject redHeartPrefab;
    public GameObject grayHeartPrefab;
    public int initX, initY, xSpace;
    private List<GameObject> spawnedPrefabs = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        int number = GetZan.LifeTotal;
        int x = initX;
        int y = initY;
        foreach (GameObject obj in spawnedPrefabs)
        {
            Destroy(obj);
        }
        spawnedPrefabs.Clear();
        for (int i = 1; i < 4; i++)
        {
            if (number >= i)
            {
                GameObject heart = Instantiate(redHeartPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
                spawnedPrefabs.Add(heart);
            }
            else
            {
                GameObject heart = Instantiate(grayHeartPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
                spawnedPrefabs.Add(heart);
            }
            
           
            x += xSpace;
           

        }
    }
}
