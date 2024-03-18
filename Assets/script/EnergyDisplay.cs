using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Zan GetZan;
    public GameObject iconPrefab;
    public int initX, initY, xSpace, ySpace,limitX;
    private List<GameObject> spawnedPrefabs = new List<GameObject>();
    // Update is called once per frame
    void Update()
    {
        int number = GetZan.EnergyTotal;
        int x = initX;
        int y = initY;
        foreach (GameObject obj in spawnedPrefabs)
        {
            Destroy(obj);
        }
        spawnedPrefabs.Clear();



        for (int i = 0; i < number; i++)
        {
            GameObject sheild = Instantiate(iconPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
            spawnedPrefabs.Add(sheild);
            if (x > limitX)
            {
                y -= ySpace;
                x = initX;
            }
            else
            {
                x += xSpace;
            }

        }
    }
}
