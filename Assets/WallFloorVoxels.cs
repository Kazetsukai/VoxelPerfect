using UnityEngine;
using System.Collections;

public class WallFloorVoxels : MonoBehaviour {

    public GameObject _voxelProto;

    // Use this for initialization
    void Start()
    {

        // Wall
        var height = 30;
        var width = 70;

        var color = Color.blue;

        for (int y = 0; y < height; y++)
        {
            if (color.r < 0.4f)
            {
                color.r += 0.1f;
                color.g += 0.1f;
            }

            for (int x = 0; x < width; x++)
            {
                var pos = new Vector3((-width / 2) + x, y, 0);
                var voxel = (GameObject)Instantiate(_voxelProto, pos, Quaternion.identity);
                voxel.transform.parent = transform.parent;
                voxel.GetComponent<Renderer>().material.color = color;
            }
        }

        // Floor

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var amount = 0.4f + ((y + x) % 2 == 0 ? 0.1f : 0.0f);
                color = new Color(amount, amount, amount);

                var pos = new Vector3((-width / 2) + x, 0, -(1 + y));
                var voxel = (GameObject)Instantiate(_voxelProto, pos, Quaternion.identity);
                voxel.transform.parent = transform.parent;
                voxel.GetComponent<Renderer>().material.color = color;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
