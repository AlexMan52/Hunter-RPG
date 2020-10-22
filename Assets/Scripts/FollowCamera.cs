using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float cameraRotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
        /*if (Input.GetMouseButton(1))
        {
            float xInput = Input.GetAxis("Mouse X");
            float yInput = Input.GetAxis("Mouse Y");
            transform.RotateAround(target.position, transform.up, xInput * cameraRotSpeed * Time.deltaTime);
            transform.RotateAround(target.position, transform.right, yInput * cameraRotSpeed * Time.deltaTime);
            //offset = transform.position - target.position;
        }*/
    }
}
