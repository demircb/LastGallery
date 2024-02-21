using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        public float turnRate = 100.0f;
        public float speed = 5.0f;
        public GameObject XRrig; // Reference to your XR Rig GameObject
        public GameObject camera;
        private bool isPCViewActive = false;
        private float verticalRotation = 0.0f;
        public float verticalRotationLimit = 80.0f; // Limit for vertical rotation

        void Update()
        {
            // Check for Enter key press to toggle views
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ToggleView();
            }

            // If PC view is active, enable movement and turning
            if (isPCViewActive)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = -Input.GetAxis("Mouse Y"); // Inverted Y for natural mouse-look

                Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                transform.Translate(movement * speed * Time.deltaTime);

                // Rotate the player based on mouse movement
                transform.Rotate(Vector3.up, mouseX * turnRate * Time.deltaTime);

                // Calculate new vertical rotation, clamp it, and apply it to the camera
                verticalRotation += mouseY * turnRate * Time.deltaTime;
                verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
                camera.transform.localEulerAngles = new Vector3(verticalRotation, camera.transform.localEulerAngles.y, 0.0f);
            }
        }

        void ToggleView()
        {
            // Toggle the active state of the PC view and XR Rig
            isPCViewActive = true;
            XRrig.SetActive(false);
            camera.SetActive(true);
            this.gameObject.SetActive(true);
        }
    }

