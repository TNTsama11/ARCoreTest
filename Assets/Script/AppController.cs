using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.Examples;
using GoogleARCore.Examples.Common;

public class AppController : MonoBehaviour {
    public GameObject TrackedPlanePerfab;
    public GameObject FirstPersonCamera;
    public GameObject unityPrefab;
    private const float k_ModelRotation = 180.0f;
    private List<DetectedPlane> m_NewPlanes = new List<DetectedPlane>();
    private List<DetectedPlane> m_AllPlanes = new List<DetectedPlane>();
    bool flag=true;
    void Start () {
        //QuitOnConnectionErrors();
	}
	
	void Update () {
        if (Session.Status!= SessionStatus.Tracking)
        {
            const int LOST_TRACKING_SLEEP_TIMEOUT = 15;
            Screen.sleepTimeout =LOST_TRACKING_SLEEP_TIMEOUT;
            return;
        }
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        Session.GetTrackables<DetectedPlane>(m_NewPlanes, TrackableQueryFilter.New);
        for(int i = 0; i < m_NewPlanes.Count; i++)
        {
            GameObject planeObject = Instantiate(TrackedPlanePerfab, Vector3.zero, Quaternion.identity,transform);
            planeObject.GetComponent<DetectedPlaneVisualizer>().Initialize(m_NewPlanes[i]);
        }
        Session.GetTrackables<DetectedPlane>(m_AllPlanes);

        //hit
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
            TrackableHitFlags.FeaturePointWithSurfaceNormal;
        if (flag==true)
        { 
        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            // Use hit pose and camera pose to check if hittest is from the
            // back of the plane, if it is, no need to create the anchor.
            if ((hit.Trackable is DetectedPlane) &&
                Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
                    hit.Pose.rotation * Vector3.up) < 0)
            {
                Debug.Log("Hit at back of the current DetectedPlane");
            }
            else 
            {
                // Instantiate Andy model at the hit pose.
                var unObject = Instantiate(unityPrefab, hit.Pose.position, hit.Pose.rotation);
                    flag = false;

                // Compensate for the hitPose rotation facing away from the raycast (i.e. camera).
                unObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);

                // Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
                // world evolves.
                var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                // Make Andy model a child of the anchor.
                unObject.transform.parent = anchor.transform;
            }

                

                
        }
        }
    }
    private void QuitOnConnectionErrors()
    {
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            ShowAndoridToastMessage("没有摄像头使用权限");
            Application.Quit();
            //Invoke("_DoQuit", 0.5f);

        }
        else if (Session.Status.IsError())
        {
            ShowAndoridToastMessage("ARCore遇到连接问题,请再次启动应用。");
            Application.Quit();
        }
    }
    private static void ShowAndoridToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        if (unityActivity!=null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
             {
                 AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
                 toastObject.Call("show");
             }));
        }
    }
}
