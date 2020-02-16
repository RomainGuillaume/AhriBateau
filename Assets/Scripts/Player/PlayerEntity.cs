using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plank;
using Crystal;
using Rift;

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
        GameObject currentRift;
        bool isRepairing = false;
        float amountRepair = 0f;

        public float speedRepair = 100f;
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
            PlayerController.Instance.UpdatePlayerPlankCounter(this);
        }

        public void RemoveWood(int count = 1)
        {
            wood -= count;
            PlayerController.Instance.UpdatePlayerPlankCounter(this);
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
                if (!isRepairing)
                {
                    UpdateMovement();
                }
                
                OnPressFire();
                UpdateAmountRepair();
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
            CollideRift(other, true);
        }

        void OnTriggerExit(Collider other)
        {
            CollideRift(other, false);
        }

        void UpdateAmountRepair()
        {
            if (isRepairing && amountRepair < 100)
            {
                amountRepair += speedRepair * Time.deltaTime;
            }
            else
            {
                if (amountRepair >= 100)
                {
                    RemoveWood(2);
                    RiftController.Instance.RepairComplete(currentRift);
                }

                amountRepair = 0;
            }
        }

        void OnPressFire()
        {
            if (Input.GetAxis("Fire1") > 0 && currentRift != null)
            {
                if (isRepairing == false)
                {
                    amountRepair = 0;
                    RiftController.Instance.StartRepair(speedRepair);

                    if (currentRift != null)
                    {
                        Vector3 target = new Vector3(currentRift.gameObject.transform.position.x, transform.position.y, currentRift.gameObject.transform.position.z);
                        transform.LookAt(target, Vector3.up);
                    }
                }

                isRepairing = true;
            }
            else if (isRepairing)
            {
                RiftController.Instance.StopRepair();
                isRepairing = false;
            }
        }

        void CollideRift(Collider other, bool toogle)
        {
            if (other.gameObject.GetComponent<RiftEntity>() != null)
            {
                RiftController.Instance.TogglePanelPress(other.gameObject, toogle);

                if (toogle && currentRift == null && wood >= 2)
                {
                    currentRift = other.gameObject;
                }
                else if (!toogle)
                {
                    currentRift = null;
                }
            }
        }

        void PickUp(Collider other)
        {
            if (other.gameObject.GetComponent<PlankEntity>() != null)
            {
                AddWood();
                Destroy(other.gameObject);
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
