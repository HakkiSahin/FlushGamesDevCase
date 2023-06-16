using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridSystem : MonoBehaviour
{
    public int gridSizeX = 4;
    public int gridSizeZ = 3;
    public float cellSize = 1.4f;
    public List<Vector3> cubePositions = new List<Vector3>();

    public GemScriptable _gemScriptable;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 bottomLeft = transform.position -
                             new Vector3(gridSizeX * cellSize * 0.5f, 0f, gridSizeZ * cellSize * 0.5f);

        cubePositions.Clear();

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                Vector3 cellCenter = bottomLeft +
                                     new Vector3(x * cellSize + cellSize * 0.5f, 0f, z * cellSize + cellSize * 0.5f);
                cubePositions.Add(cellCenter);
                Gizmos.DrawWireCube(cellCenter, new Vector3(cellSize, 0.1f, cellSize));
            }
        }
    }


    public void Start()
    {
        for (int i = 0; i < cubePositions.Count; i++)
        {
            CreateGem(cubePositions[i]);
        }
    }


    public void CreateGem(Vector3 createPos)
    {
        int randomGem = Random.Range(0, _gemScriptable.gemList.Count);

        GameObject gem = Instantiate(
            _gemScriptable.gemList[randomGem].gemPrefabs, createPos,
            Quaternion.identity, transform);

        gem.GetComponent<Gem>().gemValue = _gemScriptable.gemList[randomGem].gemValue;
    }
}