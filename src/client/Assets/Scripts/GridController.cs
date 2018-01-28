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
        Vector3 test = getMouseHexWorldCoord().getPosition();
        Vector3 test2 = getWorldCoordsFromHex(getNearestHexCoord(test));
        print(test.x + ", " + test.z + ") -- (" + test2.x + ", " + test2.z + ")");
    }

    private HexPosition getMouseHexWorldCoord()
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
        y = ((SQRT32 * coord.y * SIZE) + ((coord.y % 2) * SQRT32 * SIZE));

        return new Vector3(x, 0, y);
    }



    private Vector2Int getNearestHexCoord(Vector3 coord)
    {
        float yy = 1 / SQRT32 * coord.z / SIZE + 1;
        float xx = coord.x / SIZE + yy / 2 + 0.5f;
        int u = Mathf.FloorToInt((Mathf.Floor(xx) + Mathf.Floor(yy)) / 3);
        int v = Mathf.FloorToInt((xx - yy + u + 1) / 2);

        print(v + " " + u);
        return (new Vector2Int(v,u));
    }
}
