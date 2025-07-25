using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowCam : MonoBehaviour
{
    private Transform target;

    [SerializeField] private float speed;

    [SerializeField] private Vector2 mapMinSize = new Vector2(-14f, -8f);
    [SerializeField] private Vector2 mapMaxSize = new Vector2(12f, 11f);

    private float cameraWidth;
    private float cameraHeight;

    private void Awake()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

    private void Start()
    {
        Camera cam = GetComponent<Camera>();
        cameraHeight = cam.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
    }

    private void FixedUpdate()
    {
        Vector3 destPos = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), speed * Time.fixedDeltaTime);
        float x = Mathf.Clamp(destPos.x, mapMinSize.x + cameraWidth, mapMaxSize.x - cameraWidth);
        float y = Mathf.Clamp(destPos.y, mapMinSize.y + cameraHeight, mapMaxSize.y - cameraHeight);
        destPos = new Vector3(x, y, destPos.z);

        transform.position = destPos;
    }
}
