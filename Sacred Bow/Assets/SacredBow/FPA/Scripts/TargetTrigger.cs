using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPA
{

public class TargetTrigger : MonoBehaviour
{
    public GameObject targetToDestroy;

    public GameObject objectToDisable;

    public GameObject targetPrefab;

    public int targetsToSpawn;

    public static int targetCount = 0;

    public GameObject abc;

    public Vector3 spawnArea = new Vector3(3, 3, 4);

    public Vector3 spawnPosition = new Vector3(3, 3, 4);

        public GameObject welcomeScreen;


        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

                Destroy(welcomeScreen);

                abc.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);

            objectToDisable.SetActive(true);

            PlayerMovement.canMove = false;

            Destroy(targetToDestroy);

            SpawnTargets();

        }

    }

    void SpawnTargets()
    {

        float xMin = spawnPosition.x - spawnArea.x / 2;
        float yMin = spawnPosition.y - spawnArea.y / 2;
        float zMin = spawnPosition.z - spawnArea.z / 2;
        float xMax = spawnPosition.x + spawnArea.x / 2;
        float yMax = spawnPosition.y + spawnArea.y / 2;
        float zMax = spawnPosition.z + spawnArea.z / 2;

        for (int i = 0; i < targetsToSpawn; i++)
        {
            float xRandom = Random.Range(xMin, xMax);
            float yRandom = Random.Range(yMin, yMax);
            float zRandom = Random.Range(zMin, zMax);

            Vector3 randomPosition = new Vector3(xRandom, yRandom, zRandom);

            Instantiate(targetPrefab, randomPosition, targetPrefab.transform.rotation);

            targetCount++;
        }



    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(spawnPosition, spawnArea);
    }
}
}

