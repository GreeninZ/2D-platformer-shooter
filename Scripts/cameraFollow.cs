using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() {
        transform.position = Target.position+offset;
        pos = transform.position;
        
        if (transform.position.y < -10)
        {
            pos.y = -10f;
            transform.position = pos;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
