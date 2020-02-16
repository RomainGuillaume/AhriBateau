using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plank;
using Crystal;

namespace Player
{
    public class PlayerEntity : MonoBehaviour
    {
        Vector3 newPos;
        bool isValid = false;
        Vector3 direction = Vector3.zero;
        Rigidbody Rb;
        float distToGround;
        float drag;

        public float maxSpeed = 5f;
        public bool stop = false;
        public float speed = 5.75f;
        public int wood = 0;
        public float gravity = 500f;
        public GameObject Model3D {
            get => transform.GetChild(0).gameObject;
        }

        public void AddWood()
        {
            wood++;
        }

        public void Reset(Vector3 newpos)
        {
            direction = Vector3.zero;
            transform.position = newpos;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Rb.velocity = Vector3.zero;
        }

        void Start()
        {
            Rb = GetComponent<Rigidbody>();
            isValid = Rb != null;
            distToGround = GetComponent<Collider>().bounds.extents.y;
            drag = Rb.drag;
        }

        void Update()
        {
            if (isValid && !stop)
            {
                UpdateMovement();
            }
        }

        void UpdateMovement()
        {
            Rb.drag = !IsGrounded() ? 0 : drag;

            direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;

            if (direction.x != 0 || direction.z != 0 && !(direction.x == 0 && direction.z == 0))
            {
                Vector3 newAngleDirection = new Vector3(direction.x, 0, direction.z);
                transform.rotation = Quaternion.LookRotation(newAngleDirection, Vector3.up);
            }

            if (Rb.velocity.magnitude > maxSpeed)
            {
                Vector3 limitedVelocity = Vector3.ClampMagnitude(Rb.velocity, maxSpeed);
                Rb.velocity = new Vector3(limitedVelocity.x, Rb.velocity.y, limitedVelocity.z);
            }

            if (IsGrounded())
            {
                Rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                Rb.AddForce(direction);
            }
            else
            {
                Rb.constraints = RigidbodyConstraints.None;
            }
        }

        bool IsGrounded() {
            return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        }

        void OnTriggerEnter(Collider other)
        {
            PickUp(other);
        }

        void PickUp(Collider other)
        {
            if (other.gameObject.GetComponent<PlankEntity>() != null)
            {
                AddWood();
                Destroy(other.gameObject);
                PlayerController.Instance.UpdatePlayerPlankCounter(this);
            }

            if (other.gameObject.GetComponent<CrystalEntity>() != null)
            {
                gameObject.GetComponent<PlayerEntity>().AddPotEffect(other.gameObject.GetComponent<CrystalEntity>().color);
                Destroy(other.gameObject);

            }
        }

        void AddPotEffect(int crystal)
        {

        }

    }
}
