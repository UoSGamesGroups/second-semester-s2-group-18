using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

    public GameObject Player1, Player2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(LevelController.GameActive)
        {
            FixedCameraFollowSmooth(Camera.main, Player1.transform, Player2.transform);
        } else
        {
            if(Camera.main.transform.parent == null)
            {
                Camera.main.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
                Camera.main.transform.Translate(GameObject.FindGameObjectWithTag("Player").transform.position);
                Camera.main.orthographicSize = 6.5f;
            }
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(Camera.main.transform.parent.transform.position.x, Camera.main.transform.parent.transform.position.x, -10), 10 * Time.deltaTime);
        }

    }

    // Follow Two Transforms with a Fixed-Orientation Camera
    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        // How many units should we keep from the players
        float zoomFactor = 1.5f;
        float followTimeDelta = 0.8f;

        // Midpoint we're after
        Vector3 midpoint = (t1.position + t2.position) / 2f;

        // Distance between objects
        float distance = (t1.position - t2.position).magnitude;

        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        // Adjust ortho size if we're using one of those
        if (cam.orthographic)
        {
                // The camera's forward vector is irrelevant, only this size will matter
                cam.orthographicSize = Mathf.Max(distance, 6.5f);

        }
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = cameraDestination;
    }

    IEnumerator MoveToCameraPos(Vector2 pos)
    {
        Camera cam = Camera.main;
        if(cam.transform.position != (Vector3)pos)
        {
            Vector2.MoveTowards(cam.transform.position, pos, 1f);
            yield return new WaitForSeconds(0.000001f);
        }
    }
}
