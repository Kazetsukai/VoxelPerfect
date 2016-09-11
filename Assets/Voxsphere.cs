using UnityEngine;
using System.Collections;

public class Voxsphere : MonoBehaviour {

    public GameObject _voxelProto;
    const int SIZE = 12;

    Vector3 origPos;

    //bool[,,] sphere = new bool[SIZE, SIZE, SIZE];

	// Use this for initialization
	void Start () {
        origPos = transform.localPosition;
        Vector3 vec = new Vector3();
        var sqrRad = (SIZE - 1) * (SIZE - 1);

	    for (int x = -SIZE; x < SIZE; x++)
        {
            for (int y = -SIZE; y < SIZE; y++)
            {
                for (int z = -SIZE; z < SIZE; z++)
                {
                    vec.Set(x, y*2, z);
                    if (vec.sqrMagnitude < sqrRad)
                    {
                        var pos = new Vector3(x, y, z);
                        var voxel = (GameObject)Instantiate(_voxelProto);
                        voxel.transform.parent = transform;
                        voxel.transform.localPosition = pos;

                        var amount = 0.4f + 0.3f * (y / (float)SIZE);
                        var color = new Color(amount, amount, amount);
                        voxel.GetComponent<Renderer>().material.color = color;
                    }
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        // Wobble
        transform.localPosition = origPos + new Vector3((int)(Mathf.Sin(Time.timeSinceLevelLoad) * 5), 0, 0);
	}
}
