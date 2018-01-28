using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

	// Use this for initialization
	void Start () {
        for (int x = GridController.gridMinX; x <= GridController.gridMaxX; x++)
        {
            //TODO
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnOre (Vector3 pos)
    {
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(25, 25, 25);
        sphere.transform.position = pos;
    }
}
