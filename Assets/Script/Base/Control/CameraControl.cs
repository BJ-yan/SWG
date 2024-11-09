namespace Base.Control
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class CameraControl : MonoBehaviour
    {
        private string TAG = "CameraControl";
        public bool IsInteracte = true;
        public float moveSpeed = 0.1f;
        public float dragSpeed = 0.02f;
        public float zoomSpeed = 1.0f;

        [Header("相机活动范围")]
        public float topPar = 0.0f;
        public float bottomPar = 0.0f;
        public float leftPar = 0.0f;
        public float rightPar = 0.0f;
        public float far = 120.0f;
        public float near = 10.0f;

        // 记录鼠标滚轮当前值
        private float mouseWheel_;
        // 鼠标移动到屏幕边缘的差值
        private float mouseOffset_ = 0.01f;
        private bool mouseIsDrag_ = false;
        private Vector3 mouseEndPos_;
        private Camera cam_;
        private Transform camTrans_;

        private void Awake()
        {
            cam_ = GetComponent<Camera>();
            camTrans_ = cam_.transform;

            SetCameraInitPos(new Vector3(0, 50, -80));
            SetCameraInitAngle(new Vector3(35, 0, 0));
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
            }
            else
            {
                if (mouseIsDrag_) mouseIsDrag_ = false;
            }
        }

        ///<summary>
        ///设置相机位置
        ///</summary>
        public void SetCameraInitPos(Vector3 pos)
        {
            camTrans_.position = new Vector3(pos.x, pos.y, camTrans_.position.z);
        }

        ///<summary>
        ///设置摄像机旋转
        ///</summary>
        private void SetCameraInitAngle(Vector3 pos)
        {
            camTrans_.eulerAngles  = new Vector3(pos.x, pos.y, pos.z);
        }

        ///<summary>
        ///鼠标在屏幕边缘时移动相机
        ///</summary>
        private void mouseInScreenBound()
        {
            Vector3 v1 = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //左移
            if (v1.x <= mouseOffset_)
            {
                if (camTrans_.position.x - moveSpeed >= leftPar)
                {
                    camTrans_.Translate(new Vector3(-moveSpeed, 0, 0));
                }
            }
            //右移
            if (v1.x >= 1 - mouseOffset_)
            {
                if (camTrans_.position.x + moveSpeed <= rightPar)
                {
                    camTrans_.Translate(new Vector3(moveSpeed, 0, 0));
                }
            }
        }

        /// <summary>
        /// 按下对应键位时，移动相机
        /// </summary>
        private void keyCodeMoveCamera()
        {
            if (Input.GetKey(KeyCode.W))
            {
                camTrans_.position = new Vector3(camTrans_.position.x, camTrans_.position.y, camTrans_.position.z + moveSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                camTrans_.position = new Vector3(camTrans_.position.x, camTrans_.position.y, camTrans_.position.z - moveSpeed);
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
            if (mouseWheel_ < 0.0f && cam_.fieldOfView <= far)
            {
                cam_.fieldOfView += 10 * zoomSpeed * Time.deltaTime;
            }
            else if (mouseWheel_ > 0.0f && cam_.fieldOfView >= near)
            {
                cam_.fieldOfView -= 10 * zoomSpeed * Time.deltaTime;
            }
        }
    }
}
