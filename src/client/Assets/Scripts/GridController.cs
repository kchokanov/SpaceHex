using System.Collections.Generic;
using UnityEngine;


public class GridController : MonoBehaviour
{

    public static int gridMinX = -29;
    public static int gridMaxX = 29;
    public static int gridMinY = -27;
    public static int gridMaxY = 29;
    public static int gridMinYLeft= -43;
    public static int gridMaxYLeft = 13;
    public static int gridMaxYRight = 43;
    public static int gridMinYRight= -13;

    public static Vector3 highlightHex;

    private const float SQRT32 = 0.86602540378443864676372317075294f;
    private const int SIZE = 20;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Selected Hex Coordinates
        highlightHex = getWorldCoordsFromHex(getNearestHexCoord(getMouseHexWorldCoord().getPosition()));
        //Debug.Log("HexC: X = " + highlightHex.x + ", Z = " + highlightHex.z);
    }

    public HexPosition getMouseHexWorldCoord()
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
            return (new HexPosition(hits[min].point));
        }
    }

    private Vector3 getWorldCoordsFromHex( Vector2 coord )
    {
        float x = 0;
        float y = 0;
        float actY = coord.y - coord.x / 2f; 
        x = (1.5f * SIZE) * coord.x;
        y = (SQRT32 * SIZE) * (actY * 2);
        return new Vector3(x, 0, y);
    }



    private Vector2Int getNearestHexCoord(Vector3 coord)
    {
        float yy = 1 / SQRT32 * coord.z / SIZE + 1;
        float xx = coord.x / SIZE + yy / 2 + 0.5f;
        int u = Mathf.FloorToInt((Mathf.Floor(xx) + Mathf.Floor(yy)) / 3);
        int v = Mathf.FloorToInt((xx - yy + u + 1) / 2);

        Debug.Log("HexX:" + v + " HexY:" + u);
        return (new Vector2Int(v,u));
    }
}
