//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

//public static class GameConstants
//        {
//            public static Vector3 CameraAngleOffset { get; set; }
//            public static Vector3 CameraPositionOffset { get; set; }
//            public static float Damping { get; set; }

//        }
//public class ThirdPersonCamera : MonoBehaviour
//{
//    public abstract class TPCBase
//    {
//        protected Transform mCameraTransform;
//        protected Transform mPlayerTransform;

//        public Vector3 mAngleOffset = new Vector3(0.0f, 0.0f, 0.0f);
//        [Tooltip("The damping factor to smooth the changes in position androtation of the camera.")]
//        public float mDamping = 1.0f;

//        TPCBase mThirdPersonCamera;
//        public Transform mPlayer;


//        public class TPCTrack : TPCBase
//        {
//            public TPCTrack(Transform cameraTransform, Transform playerTransform)
//            : base(cameraTransform, playerTransform)
//            {
//            }
//            public override void Update()
//            {
//                Vector3 targetPos = mPlayerTransform.position;
//                mCameraTransform.LookAt(targetPos);






//            }
//        }
//        void Start()
//        {


//            mThirdPersonCamera = new TPCTrack(transform, mPlayer);
//            // Set the game constant parameters to the GameConstants class.
//            GameConstants.Damping = mDamping;
//            GameConstants.CameraPositionOffset = mPositionOffset;
//            GameConstants.CameraAngleOffset = mAngleOffset;
//        }
//        void LateUpdate()
//        {
//            mThirdPersonCamera.Update();
//        }
//        // Get from Unity Editor.
//        public Vector3 mPositionOffset = new Vector3(0.0f, 2.0f, -2.5f);
//        public Transform CameraTransform
//        {
//            get
//            {
//                return mCameraTransform;
//            }
//        }
//        public Transform PlayerTransform
//        {
//            get
//            {
//                return mPlayerTransform;
//            }
//        }
//        public TPCBase(Transform cameraTransform, Transform playerTransform)
//        {
//            mCameraTransform = cameraTransform;
//            mPlayerTransform = playerTransform;
//        }
//        public abstract void Update();
//    }
    
    
//}