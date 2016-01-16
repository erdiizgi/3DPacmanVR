using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System; 

public class Maze : MonoBehaviour {

    public string fileName;

	public GameObject wallPrefab;

	private float x;
	private float z;


	// Use this for initialization
	void Start () {
		x = 0;
		z = 0;
		this.Load ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private bool Load()
    {
        // Handle any problems that might arise when reading the text
        try
        {
            string line;
            // Create a new StreamReader, tell it which file to read and what encoding the file
            // was saved as
			StreamReader theReader = new StreamReader("Assets/Resources/" + fileName + ".txt", Encoding.Default);
            // Immediately clean up the reader after this block of code is done.
            // You generally use the "using" statement for potentially memory-intensive objects
            // instead of relying on garbage collection.
            // (Do not confuse this with the using directive for namespace at the 
            // beginning of a class!)
            using (theReader)
            {
                // While there's lines left in the text file, do this:
                do
                {
                    line = theReader.ReadLine();

                    if (line != null)
                    {
						for(int i = 0 ; i < line.Length ; i++){
							string cur = line.Substring(i, 1);

							switch(cur){
							case "#":
								Instantiate(wallPrefab, new Vector3(x, 0, z), Quaternion.identity);

								x = x + 2;
								break;
							case " ":
								x = x + 2;
								break;
							}
						}

						z = z + 2;
						x = 0;

                    }
                }
                while (line != null);
                // Done reading, close the reader and return true to broadcast success    
                theReader.Close();
                return true;
            }
        }
        // If anything broke in the try block, we throw an exception with information
        // on what didn't work
        catch (Exception e)
        {
            Debug.LogError(e);
            return false;
        }
    }
 
}
