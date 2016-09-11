using UnityEngine;
using System.Collections;

public class CameraFlip : MonoBehaviour {

    public Vector3 focusPos = Vector3.zero;
    float amount = 0;
    public bool toggle = false;
    public GameObject stretcher;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (toggle)
        {
            if (amount < 1)
                amount += Time.deltaTime;
            if (amount >= 1)
                amount = 1;
        }
        else
        {
            if (amount > 0)
                amount -= Time.deltaTime;
            if (amount <= 0)
                amount = 0;
        }

        Vector3 backPos = focusPos + (Vector3.up + Vector3.back) * 100;
        Vector3 leftPos = focusPos + (Vector3.up + Vector3.left) * 100;

        Camera.main.transform.position = backPos * (1-amount) + leftPos * amount;
        Camera.main.transform.LookAt(focusPos, Vector3.up);

        stretcher.transform.localScale = new Vector3(1, 1.414f, 1.414f) * (1-amount) + new Vector3(1.414f, 1.414f, 1) * amount;

        float scaleFactor = 1f;
        Camera.main.orthographicSize = (Camera.main.pixelHeight / (float)scaleFactor) / 2;

        focusPos.Set(10 + Mathf.Sin(Time.timeSinceLevelLoad * 0.457f) * 15, 1, -9 + Mathf.Cos(Time.timeSinceLevelLoad * .976f) * 9);
        focusPos.x = (int)focusPos.x + 0.5f;
        focusPos.y = (int)focusPos.y;
        focusPos.z = (int)focusPos.z + 0.5f;

        if (Input.GetMouseButtonDown(0))
            toggle = !toggle;
    }
}
