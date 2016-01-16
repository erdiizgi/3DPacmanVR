using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

public class Maze : MonoBehaviour
{
    public TextAsset useLevel;
    public GameObject WallPrefab;
    public GameObject FloorPrefab;
    public GameObject PlayerPrefab;
    public GameObject GhostPrefab;

    public float WallSize;

    private List<Object> spawnedItems;

    // Use this for initialization
    private void Start()
    {
        spawnedItems = new List<Object>();
        ReloadMap();
    }

    public bool ReloadMap()
    {
        // Handle any problems that might arise when reading the text
        try
        {

            if (useLevel == null)
                return false;

            float x = 0, z = 0;


            foreach (var line in useLevel.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (var character in line)
                {
                    switch (character)
                    {
                        case '#':
                            spawnedItems.Add(Instantiate(WallPrefab, new Vector3(x, 0, z), Quaternion.identity));
                            break;

                        case ' ':
                            spawnedItems.Add(Instantiate(FloorPrefab, new Vector3(x, -WallSize, z), Quaternion.identity));
                            break;

                        case 'P':
                            spawnedItems.Add(Instantiate(FloorPrefab, new Vector3(x, -WallSize, z), Quaternion.identity));

                            if (Application.isPlaying)
                                spawnedItems.Add(Instantiate(PlayerPrefab, new Vector3(x, 0, z), Quaternion.identity));

                            break;

                        case 'G':
                            spawnedItems.Add(Instantiate(FloorPrefab, new Vector3(x, -WallSize, z), Quaternion.identity));

                            if (Application.isPlaying)
                                spawnedItems.Add(Instantiate(GhostPrefab, new Vector3(x, 0, z), Quaternion.identity));
                            break;
                    }
                    x += WallSize;
                }

                z += WallSize;
                x = 0;
            }

        }
        // If anything broke in the try block, we throw an exception with information
        // on what didn't work
        catch (Exception e)
        {
            if (e != null)
                Debug.LogError(e);
            return false;
        }

        return true;
    }

    public void ClearMaze()
    {
        if (spawnedItems == null)
            spawnedItems = new List<Object>();

        for (int i = 0; i < spawnedItems.Count; i++)
        {
            if (Application.isEditor)
                DestroyImmediate(spawnedItems[i]);
            else
                Destroy(spawnedItems[i]);
        }
    }
}