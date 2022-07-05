using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasts : MonoBehaviour
{
    public LayerMask layerMask;
    public float angle;
    public float distance = 1f;

    public GameObject rightObj;
    public GameObject leftObj;

    public bool canLeft = false;
    public bool canFoward = false;
    public bool canRight = false;

    public RaycastHit leftHit;
    public RaycastHit fowardHit;
    public RaycastHit rightHit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //RayTest();

        LeftRayCast();
        FowardRayCast();
        RightRayCast();
    }

    void LeftRayCast()
    {
        var direction = Quaternion.AngleAxis(angle, transform.right) * transform.forward;

        Ray ray = new Ray(leftObj.transform.position, direction);

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.red);

        if (Physics.Raycast(ray, out leftHit, layerMask))
        {
            canLeft = true;
        }
        else
        {
            canLeft = false;
        }
    }
    void FowardRayCast()
    {
        var direction = Quaternion.AngleAxis(angle, transform.right) * transform.forward;

        Ray ray = new Ray(transform.position, direction);

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.red);

        if (Physics.Raycast(ray, out fowardHit, layerMask))
        {
            canFoward = true;
        }
        else
        {
            canFoward = false;
        }
    }
    void RightRayCast()
    {
        var direction = Quaternion.AngleAxis(angle, transform.right) * transform.forward;

        Ray ray = new Ray(rightObj.transform.position, direction);

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.red);

        if(Physics.Raycast(ray,out rightHit, layerMask))
        {
            canRight = true;
        }
        else
        {
            canRight = false;
        }
    }
}
