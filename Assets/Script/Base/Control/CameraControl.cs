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

        private void Update()
        {
            if (IsInteracte)
            {
               if (!mouseIsDrag_)
                {
                    mouseInScreenBound();
                }
                keyCodeMoveCamera();
                mouseDragCameraMove();
                mouseScrollWheelChangeView();
                // restrictCameraPosition();
            }
            else
            {
                if (mouseIsDrag_) mouseIsDrag_ = false;
            }
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

        ///<summary>
        ///鼠标在屏幕边缘时移动相机
        ///</summary>
        private void mouseInScreenBound()
        {
            Vector3 v1 = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //上移动
            if (v1.y >= 1 - mouseOffset_)
            {
                camTrans_.Translate(Vector2.up * moveSpeed);
            }
            //下移动
            if (v1.y <= mouseOffset_)
            {
                camTrans_.Translate(Vector2.down * moveSpeed);
            }
            //左移
            if (v1.x <= mouseOffset_)
            {
                camTrans_.Translate(Vector2.left * moveSpeed);
            }
            //右移
            if (v1.x >= 1 - mouseOffset_)
            {
                camTrans_.Translate(Vector2.right * moveSpeed);
            }
        }

        /// <summary>
        /// 按下对应键位时，移动相机
        /// </summary>
        private void keyCodeMoveCamera()
        {
            if (Input.GetKey(KeyCode.W))
            {
                camTrans_.Translate(Vector2.up * moveSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                camTrans_.Translate(Vector2.down * moveSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                camTrans_.Translate(Vector2.left * moveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                camTrans_.Translate(Vector2.right * moveSpeed);
            }
        }

        /// <summary>
        /// 鼠标拖动相机移动
        /// </summary>
        private void mouseDragCameraMove()
        {
            if (!mouseIsDrag_ && Input.GetMouseButtonDown(0))
            {
                mouseEndPos_ = Input.mousePosition;
                mouseIsDrag_ = true;
            }
            if (mouseIsDrag_ && Input.GetMouseButton(0))
            {
                Vector3 curPos = Input.mousePosition;
                Vector3 movePos = (curPos - mouseEndPos_) * dragSpeed;
                camTrans_.position -= movePos;
                mouseEndPos_ = curPos;
            }
            if (mouseIsDrag_ && Input.GetMouseButtonUp(0))
            {
                mouseIsDrag_ = false;
            }
        }

        /// <summary>
        /// 鼠标滚轮改变视野范围
        /// </summary>
        private void mouseScrollWheelChangeView()
        {
            mouseWheel_ = Input.GetAxis("Mouse ScrollWheel");//获取滚轮值的改变
            //视野放大
            if (mouseWheel_ < 0 && cam_.orthographicSize + zoomSpeed <= maxSize)
            {
                cam_.orthographicSize += zoomSpeed;
            }
            //视野缩小
            else if (mouseWheel_ > 0 && cam_.orthographicSize - zoomSpeed >= minSize)
            {
                cam_.orthographicSize -= zoomSpeed;
            }
        }

         /// <summary>
        /// 限制相机位置
        /// </summary>
        private void restrictCameraPosition()
    {
        float cameraSize = cam_.orthographicSize - minSize;

        float maxY = cameraSize * topPar_ + minSizeBound[0];
        float minY = cameraSize * bottomPar_ + minSizeBound[1];
        float minX = cameraSize * leftPar_ + minSizeBound[2];
        float maxX = cameraSize * rightPar_ + minSizeBound[3];

        if (camTrans_.position.y > maxY)
        {
            camTrans_.position = new Vector3(camTrans_.position.x, maxY, camTrans_.position.z);
        }
        if (camTrans_.position.y < minY)
        {
            camTrans_.position = new Vector3(camTrans_.position.x, minY, camTrans_.position.z);
        }
        if (camTrans_.position.x < minX)
        {
            camTrans_.position = new Vector3(minX, camTrans_.position.y, camTrans_.position.z);
        }
        if (camTrans_.position.x > maxX)
        {
            camTrans_.position = new Vector3(maxX, camTrans_.position.y, camTrans_.position.z);
        }
    }
    }
}
