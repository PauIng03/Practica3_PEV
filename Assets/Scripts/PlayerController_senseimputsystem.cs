using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController_senseimputsystem : MonoBehaviour
{
    public Animator anim;
    public detector det;

    public float speed = 3;
    public float rotationSpeed = 180;
    public float gravity = -20f;
    public float jumpSpeed = 15;

    public bool PuedeHablar = true;
    public bool PuedeAndar = true;
    public bool Jumping;

    CharacterController characterController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        PuedeAndar = true;
        PuedeHablar = true;
        if (PlayerPrefs.HasKey("PosX") && PlayerPrefs.HasKey("PosY") && PlayerPrefs.HasKey("PosZ"))
        {
            float posX = PlayerPrefs.GetFloat("PosX");
            float posY = PlayerPrefs.GetFloat("PosY");
            float posZ = PlayerPrefs.GetFloat("PosZ");

            transform.position = new Vector3(posX, posY, posZ);
        }
    }

    void Update()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        if (characterController.isGrounded)
        {
            Jumping = false;
            if (PuedeAndar)
            {
                moveVelocity = transform.forward * speed * vInput;

                this.anim.SetFloat("vertical", vInput);
                this.anim.SetFloat("horizontal", hInput);
                this.anim.SetBool("run", false);
                this.anim.SetBool("jump", false);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    moveVelocity *= 2f;
                    this.anim.SetBool("run", true);
                }

                if (Input.GetButtonDown("Jump"))
                {
                    moveVelocity.y = jumpSpeed;
                    this.anim.SetBool("jump", true);
                }
            }
            else
            {
                moveVelocity = Vector3.zero;
                turnVelocity = Vector3.zero;

                this.anim.SetFloat("vertical", 0);
                this.anim.SetFloat("horizontal", 0);
                this.anim.SetBool("run", false);
                this.anim.SetBool("jump", false);
            }
        }
        else
        {
            Jumping = true;
        }

        if (!PuedeHablar)
        {
            if (det.PersonajeCerca != null)
            {
                Vector3 direction = (transform.position - det.PersonajeCerca.transform.position).normalized;
                direction.y = 0f;

                Quaternion targetRotation = Quaternion.LookRotation(direction);
                float angleDifference = Quaternion.Angle(det.PersonajeCerca.transform.rotation, targetRotation);

                // Check if the target and current rotations are significantly different
                if (angleDifference > 0.1f)
                {
                    float step = rotationSpeed * Time.deltaTime * Mathf.Min(angleDifference / 10.0f, 1.0f); // Damping factor to slow down rotation as it gets closer
                    Quaternion smoothRotation = Quaternion.RotateTowards(det.PersonajeCerca.transform.rotation, targetRotation, step);
                    det.PersonajeCerca.transform.rotation = smoothRotation;
                }
                else
                {
                    det.PersonajeCerca.transform.rotation = targetRotation; // Snap to target rotation to stop vibration
                }
            }
        }
        else
        {
            turnVelocity = transform.up * rotationSpeed * hInput;
        }

        moveVelocity.y += gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }
}
