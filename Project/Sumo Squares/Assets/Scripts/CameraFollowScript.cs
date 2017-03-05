using System.Collections;
using UnityEngine;

/// <summary>
/// This script is used to move the camera so that both players are always in viewscope if possible.
/// Otherwise, the script will adapt to different game circumstances (e.g. Only 1 player left).
/// </summary>
public class CameraFollowScript : MonoBehaviour
{
    public GameObject Player1, Player2;
    public float minCameraDistance, maxCameraDistance;

    /// <summary>
    /// The speed at which the camera moves back to the center of the stage or to the last player alive.
    /// </summary>
    public float CameraReturnSpeed;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelController.MatchActive)
        {
            FixedCameraFollowSmooth(Camera.main, Player1.transform, Player2.transform);
        }
        else
        {
            if (LevelController.CurrentPlayers.Count == 1)
            {
                GameObject lastPlayer = LevelController.CurrentPlayers[0];
                Camera.main.transform.SetParent(lastPlayer.transform);
                //Camera.main.orthographicSize = 6.5f;
                StartCoroutine(ZoomToOrthoSize(6.5f, 1.0f));
                //Camera.main.transform.position = new Vector3(0,0,-15);
                Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position,
                    new Vector3(lastPlayer.transform.position.x, lastPlayer.transform.position.y, -15),
                    CameraReturnSpeed * Time.deltaTime);
            }
            if (LevelController.CurrentPlayers.Count == 0)
            {
                StartCoroutine(ZoomToOrthoSize(6.5f, 1.0f));
                Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position,
                    new Vector3(0, 0, -15), CameraReturnSpeed * Time.deltaTime);
            }
        }
    }

    /// <summary>
    /// Follow Two Transforms with a Fixed-Orientation Camera.
    /// </summary>
    /// <param name="cam">The camera to move.</param>
    /// <param name="t1">The first transform that should kept in viewscope.</param>
    /// <param name="t2">The second transform that should kept in viewscope.</param>
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
            if(distance > maxCameraDistance)
            {
                distance = maxCameraDistance;
            }
            // The camera's forward vector is irrelevant, only this size will matter
            cam.orthographicSize = Mathf.Max(distance, minCameraDistance);
        }
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = cameraDestination;
    }

    /// <summary>
    /// Used to zoom the camera over a set amount of time.
    /// </summary>
    /// <param name="orthoSize">The goal orthographic size of the camera.</param>
    /// <param name="timeInterval">The amount of time the zoom should take.</param>
    /// <returns></returns>
    IEnumerator ZoomToOrthoSize(float orthoSize, float timeInterval)
    {
        Camera cam = Camera.main;
        float i = 0.0f;
        float rate = 1.0f / timeInterval;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, orthoSize, i);
            yield break;
        }
    }
}