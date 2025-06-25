using UnityEngine;
using UnityEngine.XR;

namespace Caputilla.Utils
{
    public class ControllerInputManager : MonoBehaviour
    {
        public static ControllerInputManager Instance;
        public bool rightTrigger, leftTrigger, rightGrip, leftGrip, leftSecondary, rightSecondary, leftPrimary, rightPrimary;
        public Vector2 leftStickAxis, rightStickAxis;
        private void Awake()
        {
            Instance = this;
        }

        void Update()
        {
            rightTrigger = InputDevices.GetDeviceAtXRNode(XRNode.RightHand)
                .TryGetFeatureValue(new InputFeatureUsage<bool>("TriggerButton"), out bool triggerl) && triggerl;
            
            leftTrigger = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand)
                .TryGetFeatureValue(new InputFeatureUsage<bool>("TriggerButton"), out bool triggerr) && triggerr;

            leftGrip = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand)
                .TryGetFeatureValue(CommonUsages.gripButton, out bool gripl) && gripl;

            rightGrip = InputDevices.GetDeviceAtXRNode(XRNode.RightHand)
                .TryGetFeatureValue(CommonUsages.gripButton, out bool griplr) && griplr;

            leftSecondary = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand)
                    .TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryl) && secondaryl;

            rightSecondary = InputDevices.GetDeviceAtXRNode(XRNode.RightHand)
                    .TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryr) && secondaryr;

            leftPrimary = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand)
                .TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryl) && primaryl;

            rightPrimary = InputDevices.GetDeviceAtXRNode(XRNode.RightHand)
                .TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryr) && primaryr;

            leftStickAxis = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand)
                    .TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primaryaxis) ? primaryaxis : Vector2.zero;

            rightStickAxis = InputDevices.GetDeviceAtXRNode(XRNode.RightHand)
                    .TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 secondaryaxis) ? secondaryaxis : Vector2.zero;
        }
    }
}