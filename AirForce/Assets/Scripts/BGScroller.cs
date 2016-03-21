using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
    public float speedScroll;
    public float tileSizeZ;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }
    // Update is called once per frame
    void Update ()
    {
        float newPosition = Mathf.Repeat(Time.time*speedScroll, tileSizeZ);
        transform.position = startPosition +  Vector3.forward*newPosition;
    }
}
