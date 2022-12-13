using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Vector3 Offset;
    public PlayerBall player;

    // Start is called before the first frame update
    void Awake()
    {
        Offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = player.transform.position + Offset;
    }
}
