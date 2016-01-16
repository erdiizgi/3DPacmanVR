using System;
using System.IO;
using System.Text;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public TextAsset useLevel;
    public GameObject WallPrefab;
    public GameObject FloorPrefab;
    public GameObject PlayerPrefab;

    public float WallSize;

    // Use this for initialization
    private void Start()
    {
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
                            Instantiate(WallPrefab, new Vector3(x, 0, z), Quaternion.identity);
                            break;

                        case ' ':
                            Instantiate(FloorPrefab, new Vector3(x, -WallSize, z), Quaternion.identity);
                            break;

                        case 'P':
                            Instantiate(PlayerPrefab, new Vector3(x, 0, z), Quaternion.identity);
                            Instantiate(FloorPrefab, new Vector3(x, -WallSize, z), Quaternion.identity);
                            break;

                        case 'G':
                            //Instantiate(GhostPrefab, new Vector3(x, 0, z), Quaternion.identity);
                            Instantiate(FloorPrefab, new Vector3(x, -WallSize, z), Quaternion.identity);
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
            Debug.LogError(e);
            return false;
        }

        return true;
    }
}