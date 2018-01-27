using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {


    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        getMouseHex();
    }

    private HexPosition getMouseHex()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        if (hits.Length == 0)
        {
            print("No hits!");
            return null;
        }
        else
        {
            float minDist = float.PositiveInfinity;
            int min = 0;
            for (int i = 0; i < hits.Length; ++i)
            {
                if (hits[i].distance < minDist)
                {
                    minDist = hits[i].distance;
                    min = i;
                }
            }

            print(hits[min].point);
            return (new HexPosition(hits[min].point));
        }
    }
}
