using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    public float RoattionSpeed;

    Rigidbody rb;

    Camera cam;

    Vector3 target;

    public Transform thingy;

    public Light SecondaryLight;
    Light mainLight;

    [Header("Light Properties")]
    public float LightAngle;
    public float SecondLightRatio;
    public float LightBrightness;
    public float SecondLightBrightnessRatio;

    public bool IsMain;

    private void Start()
    {
        cam = Camera.main;

        rb = GetComponent<Rigidbody>();

        mainLight = GetComponent<Light>();

        if (IsMain)
        {
            InvokeRepeating("update", 0, 0.1f);
        }
    }

    void update()
    {
        mainLight.spotAngle = LightAngle;
        SecondaryLight.spotAngle = LightAngle / SecondLightRatio;

        mainLight.intensity = LightBrightness;
        SecondaryLight.intensity = LightBrightness / SecondLightBrightnessRatio;
    }

    private void FixedUpdate()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;

        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            target = new Vector3(hit.point.x, 0, hit.point.z);
        }

        thingy.LookAt(target);

        Vector3 rotation = new Vector3(0, thingy.rotation.eulerAngles.y, thingy.rotation.eulerAngles.z);

        transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), RoattionSpeed);

        transform.localPosition = new Vector3(0, 0, 0);
    }
}
