using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{
    public GameObject[] startPrefabs;
    public GameObject[] tilePrefabs;

    private Transform tileFrom, tileTo;
    private void Start()
    {
       tileFrom = CreateStartTile();
       tileTo = CreateTile();
       ConnectTiles();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
    }

    Transform CreateStartTile()
    {
        //spawning start room
        int index = UnityEngine.Random.Range(0, startPrefabs.Length);
        GameObject startTile = Instantiate(startPrefabs[index], Vector3.zero, Quaternion.identity, transform);
        startTile.name = "First Room";
        float yRot = UnityEngine.Random.Range(0, 4) * 90f;                      
        startTile.transform.Rotate(0, yRot, 0);

        return startTile.transform;
    }

    Transform CreateTile()
    {
        int index = UnityEngine.Random.Range(0, tilePrefabs.Length);
        GameObject goTile = Instantiate(tilePrefabs[index], Vector3.zero, Quaternion.identity, transform);
        goTile.name = tilePrefabs[index].name;

        return goTile.transform;
    }

    void ConnectTiles()
    {
        Transform connectFrom = GetRandomConnector(tileFrom);
        if (connectFrom == null) return;
        
        Transform connectTo = GetRandomConnector(tileTo);
        if (connectFrom == null) return;
        
        connectTo.SetParent(connectFrom);
        tileTo.SetParent(connectTo);
        connectTo.localPosition = Vector3.zero;
        connectTo.localRotation = Quaternion.identity;
        connectTo.Rotate(0, 180f, 0);
        tileTo.SetParent(transform);
        connectTo.SetParent(tileTo.Find("Connectors"));

    }

    private Transform GetRandomConnector(Transform tile)
    {
        if (tile == null) return null;
        List<Connector> connectorList = tile.GetComponentsInChildren<Connector>().ToList().FindAll(x => x.isConnected == false);

        if (connectorList.Count > 0)
        {
            int connectorIndex = UnityEngine.Random.Range(0, connectorList.Count);
            connectorList[connectorIndex].isConnected = true;
            return connectorList[connectorIndex].transform;
        }
        
        return null;
    }
}
