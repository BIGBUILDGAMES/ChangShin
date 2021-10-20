
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonSharp.Examples.Utilities
{
    /// <summary>
    /// Follows one of the chosen playerApi tracking targets
    /// </summary>
    [AddComponentMenu("Udon Sharp/Utilities/Tracking Data Follower")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class OverayButton : UdonSharpBehaviour
    {
        public VRCPlayerApi.TrackingDataType trackingTarget;

        VRCPlayerApi playerApi;
        bool isInEditor;

        Vector3 pos = new Vector3(0, 0, 0.2f);

        private void Start()
        {
            playerApi = Networking.LocalPlayer;
            isInEditor = playerApi == null; // PlayerApi will be null in editor

        }

        private void LateUpdate()
        {
            // PlayerApi data will only be valid in game so we don't run the update if we're in editor
            if (isInEditor)
                return;

            VRCPlayerApi.TrackingData trackingData = playerApi.GetTrackingData(trackingTarget);
            transform.SetPositionAndRotation(trackingData.position, trackingData.rotation);
            transform.position = transform.position + transform.rotation * pos;
        }
    }
}
