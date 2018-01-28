using System.Collections.Generic;
using UnityEngine;


public class GridController : MonoBehaviour
{

    public int gridWidth;
    public int gridHeight;

    private const float SQRT32 = 0.86602540378443864676372317075294f;
    private const int SIZE = 20;

    private const float HEXWIDTH = 2*SIZE ;
    private const float HEXHEIGHT = SIZE*0.8660254037844387f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Selected Hex Coordinates
        Vector3 test = getWorldCoordsFromHex(getNearestHexCoord(getMouseHexWorldCoord().getPosition()));
        Debug.Log("HexC: X-" +test.x + ", Z-" + test.z);
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

    public Vector3 getWorldCoordsFromHex( Vector2 coord )
    {
        float x = 0;
        float y = 0;
        x = (1.5f * SIZE) * coord.x;
        if (coord.x % 2 == 0)
        {
            y = (SQRT32 * SIZE) * (coord.y * 2);
        }
        else
        {
            y = (SQRT32 * SIZE) * ((coord.y * 2) - 1);
        }

        return new Vector3(x, 0, y);
    }



    public Vector2Int getNearestHexCoord(Vector3 coord)
    {
        float yy = 1 / SQRT32 * coord.z / SIZE + 1;
        float xx = coord.x / SIZE + yy / 2 + 0.5f;
        int u = Mathf.FloorToInt((Mathf.Floor(xx) + Mathf.Floor(yy)) / 3);
        int v = Mathf.FloorToInt((xx - yy + u + 1) / 2);

        Debug.Log("HexX:" + v + " HexY:" + u);
        return (new Vector2Int(v,u));
    }
}
