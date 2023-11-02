using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ThirdPersonCamera;
using static ThirdPersonCamera.TPCBase;
using static UnityEditor.Experimental.GraphView.GraphView;

public static class GameConstants
{
    public static Vector3 CameraAngleOffset { get; set; }
    public static Vector3 CameraPositionOffset { get; set; }
    public static float Damping { get; set; }
}

public class ThirdPersonCamera : MonoBehaviour
{

public Vector3 mAngleOffset = new Vector3(0.0f, 0.0f, 0.0f);
    [Tooltip("The damping factor to smooth the changes in position and rotation of the camera.")]
    public float mDamping = 1.0f;

    public Transform mPlayer;
    TPCBase mThirdPersonCamera;

    // Get from Unity Editor.
    public Vector3 mPositionOffset = new Vector3(0.0f, 2.0f, -2.5f);
    void Start()
    {
        // Set the game constant parameters to the GameConstants class.
        GameConstants.Damping = mDamping;
        GameConstants.CameraPositionOffset = mPositionOffset;
        GameConstants.CameraAngleOffset = mAngleOffset;
        // Set to GameConstants class so that other objects can use.
        GameConstants.CameraPositionOffset = mPositionOffset;
        mThirdPersonCamera = new TPCTrack(transform, mPlayer);
    }
    void LateUpdate()
    {
        mThirdPersonCamera.Update();
    }
    public abstract class TPCBase
    {

        public static class GameConstants
        {
            public static Vector3 CameraPositionOffset { get; set; }
        }

        protected Transform mCameraTransform;
        protected Transform mPlayerTransform;
        public Transform CameraTransform
        {
            get
            {
                return mCameraTransform;
            }
        }
        public Transform PlayerTransform
        {
            get
            {
                return mPlayerTransform;
            }
        }
        public TPCBase(Transform cameraTransform, Transform playerTransform)
        {
            mCameraTransform = cameraTransform;
            mPlayerTransform = playerTransform;
        }
        public abstract void Update();


    }
}

public class TPCTrack : TPCBase
{
    public TPCTrack(Transform cameraTransform, Transform playerTransform)
    : base(cameraTransform, playerTransform)
    {
    }
    public override void Update()
    {
        Vector3 targetPos = mPlayerTransform.position;
        mCameraTransform.LookAt(targetPos);
        // We add the camera offset on the Y-axis.
        targetPos.y += GameConstants.CameraPositionOffset.y;
        mCameraTransform.LookAt(targetPos);
    }
}

public abstract class TPCFollow : TPCBase
{
public TPCFollow(Transform cameraTransform, Transform playerTransform)
: base(cameraTransform, playerTransform)
{
}
public override void Update()
{
// Now we calculate the camera transformed axes.
// We do this because our camera's rotation might have changed
// in the derived class Update implementations. Calculate the new
// forward, up and right vectors for the camera.
Vector3 forward = Vector3.forward;
Vector3 right = Vector3.right;
Vector3 up = Vector3.up;
// We then calculate the offset in the camera's coordinate frame.
// For this we first calculate the targetPos
Vector3 targetPos = mPlayerTransform.position;
// Add the camera offset to the target position.
// Note that we cannot just add the offset.
// You will need to take care of the direction as well.
//Vector3 desiredPosition = *** Your code ***;
// Finally, we change the position of the camera,
// not directly, but by applying Lerp.
//Vector3 position = Vector3.Lerp(mCameraTransform.position,
////desiredPosition, Time.deltaTime * GameConstants.Damping);
//mCameraTransform.position = position;
}
}