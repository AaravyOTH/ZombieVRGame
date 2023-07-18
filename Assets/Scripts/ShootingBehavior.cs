using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootingBehavior : MonoBehaviour
{
    public GameObject bullet;
    private InputData inputData;
    private bool entered;
    public GameObject gun;
    float shootDelay = 0.5f; // Adjust this value to control the delay between bullet spawns
    float zoomDelay = 1f;
    float shootTimer = 0f;
    //public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        inputData = GetComponentInParent<InputData>();
        entered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputData.rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool pressed))
        {
            if (pressed && Time.time > shootTimer)
            {
                PewPew();
                shootTimer = Time.time + shootDelay;
            }
        }
       /* if (inputData.leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool pressed2))
        {
            if (pressed2)
            {
                Zoom();
                shootTimer = Time.time + shootDelay;
            }
        }*/
    }

    void PewPew()
    {
        GameObject spawned = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        spawned.GetComponent<Rigidbody>().AddForce(transform.forward * 70, ForceMode.Impulse);
    }
    void Zoom()
    {
        shootTimer = shootTimer + Time.time;
        while (shootTimer > Time.time)
        {
            //transform.GetComponent<ContinuousMoveProviderBase>().moveSpeed = 14;
        }
    //    transform.GetComponent<ContinuousMoveProviderBase>().moveSpeed = 7;

    }
}
