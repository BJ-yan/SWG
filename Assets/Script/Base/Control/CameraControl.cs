namespace Base.Control
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraControl : MonoBehaviour
    {
        public bool IsInteracte = true;
        public float moveSpeed = 0.1f;
        public float dragSpeed = 0.02f;

        [Header("相机视野范围")]
        public float minSize = 6;
        public float maxSize = 12;
        public float zoomSpeed = 0.5f;

        [Header("相机活动范围")]
        public float[] minSizeBound = new float[4];
        public float[] maxSizeBound = new float[4];

        // 记录鼠标滚轮当前值
        private float mouseWheel_;
        // 鼠标移动到屏幕边缘的差值
        private float mouseOffset_ = 0.01f;
        private bool mouseIsDrag_ = false;
        private Vector3 mouseEndPos_;
        private Camera cam_;
        private Transform camTrans_;

        private float topPar_;
        private float bottomPar_;
        private float leftPar_;
        private float rightPar_;

        private void Awake()
        {
            cam_ = GetComponent<Camera>();
            camTrans_ = cam_.transform;

            SetCameraMoveParam();
            SetCameraInitPos(Vector3.zero);
        }

        ///<summary>
        /// 设置相机移动系数
        ///</summary>
        private void SetCameraMoveParam()
        {
            float sizeRange = maxSize - minSize;

            float topRange = maxSizeBound[0] - minSizeBound[0];
            float bottomRange = maxSizeBound[1] - minSizeBound[1];
            float leftRange = maxSizeBound[2] - minSizeBound[2];
            float rightRange = maxSizeBound[3] - minSizeBound[3];

            topPar_ = topRange / sizeRange;
            bottomPar_ = bottomRange / sizeRange;
            leftPar_ = leftRange / sizeRange;
            rightPar_ = rightRange / sizeRange;
        }

        ///<summary>
        ///设置相机位置
        ///</summary>
        public void SetCameraInitPos(Vector3 pos)
        {
            camTrans_.position = new Vector3(pos.x, pos.y, camTrans_.position.z);
        }
    }
}
