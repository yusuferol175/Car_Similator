using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_sc : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float camSpeed;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, target.position.y + 2.5f, transform.position.z), camSpeed);
    }
}
