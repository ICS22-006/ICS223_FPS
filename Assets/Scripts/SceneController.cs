using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);
    private int numOfEnemies;
    private GameObject[] enemies;

    private void Start()
    {
        numOfEnemies = 5;
        enemies = new GameObject[numOfEnemies];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            if (enemies[i] == null)
            {
                enemies[i] = Instantiate(enemyPrefab) as GameObject;
                enemies[i].transform.position = spawnPoint;
                float angle = Random.Range(0, 360);
                enemies[i].transform.Rotate(0, angle, 0);
            }
        }
    }
}
