using UnityEngine;

namespace Scripts.GitLesson
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float jumpHeight = 3f;
        [SerializeField] private Transform groundCheckerPivot;
        [SerializeField] private float checkGroundRadius = 0.4f;
        [SerializeField] private LayerMask groundMask;

        private CharacterController _controller;
        private float _velocity;
        private Vector3 _moveDirection;
        private bool _isGrounded;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            _isGrounded = IsOnTheGround();

            if (_isGrounded && _velocity < 0)
            {
                _velocity = -2;
            }

            Move(_moveDirection);
            DoGravity();
        }

        private void Update()
        {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                Jump();
            }
        }

        private bool IsOnTheGround()
        {
            bool result = Physics.CheckSphere(groundCheckerPivot.position, checkGroundRadius, groundMask);
            return result;
        }

        private void Move(Vector3 direction)
        {
            _controller.Move(direction * speed * Time.fixedDeltaTime);
        }

        private void DoGravity()
        {
            _velocity += gravity * Time.fixedDeltaTime;

            _controller.Move(Vector3.up * _velocity * Time.fixedDeltaTime);
        }

        private void Jump()
        {
            _velocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
}