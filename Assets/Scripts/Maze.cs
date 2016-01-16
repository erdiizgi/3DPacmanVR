using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Maze : MonoBehaviour
{
    public TextAsset useLevel;
    public GameObject WallPrefab;
    public GameObject FloorPrefab;
    public GameObject PlayerPrefab;
    public GameObject GhostPrefab;
    public GameObject PillPrefab;
    public GameObject BoostPrefab;
    public GameController Controller;

    public float WallSize;

    private List<Object> spawnedItems;

    // Use this for initialization
    private void Start()
    {
        spawnedItems = new List<Object>();
    }

    public bool ReloadMap()
    {
        ClearMaze();

        // Handle any problems that might arise when reading the text
        try
        {

            if (useLevel == null)
                return false;

            float x = 0, z = 0;
            var createdPills = 0;

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
                            createPill(x, z, ref createdPills);
                            spawnedItems.Add(Instantiate(FloorPrefab, new Vector3(x, -WallSize, z), Quaternion.identity));
                            break;
                        case '.':
                            spawnedItems.Add(Instantiate(FloorPrefab, new Vector3(x, -WallSize, z), Quaternion.identity));
                            break;


                        case 'P':
                            spawnedItems.Add(Instantiate(FloorPrefab, new Vector3(x, -WallSize, z), Quaternion.identity));

                            if (Application.isPlaying)
                            {
                                var pc =
                                    Instantiate(PlayerPrefab, new Vector3(x, 0, z), Quaternion.identity) as GameObject;

                                if (pc == null)
                                    return false;

                                Controller.Hero = pc.GetComponentInChildren<HeroController>();
                                spawnedItems.Add(pc);
                            }

                            break;

                        case 'G':
                            createPill(x, z, ref createdPills);
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

            Controller.CreatedPills = createdPills;

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

    private void createPill(float x, float z, ref int createdPills)
    {
        spawnedItems.Add(Instantiate(PillPrefab, new Vector3(x, 0, z), Quaternion.identity));
        createdPills++;
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