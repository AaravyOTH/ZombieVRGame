using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputData : MonoBehaviour
{
    public InputDevice rightController;
    public InputDevice leftController;
    public InputDevice HMD;

    // Start is called before the first frame update
    private void InitializeInputDevices()
    {
        if (!rightController.isValid)
        {
            InitializeInputDevices(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, ref rightController);
        }
        if (!leftController.isValid)
        {
            InitializeInputDevices(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref leftController);
        }
        if (!HMD.isValid)
        {
            InitializeInputDevices(InputDeviceCharacteristics.HeadMounted, ref HMD);
        }
    }

    private void InitializeInputDevices(InputDeviceCharacteristics inputDeviceCharacteristics, ref InputDevice inputDevice)
    {
        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics, inputDevices);

        if (inputDevices.Count > 0)
        {
            inputDevice = inputDevices[0];
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (!rightController.isValid || !leftController.isValid || !HMD.isValid)
        {
            InitializeInputDevices();
        }
    }
}