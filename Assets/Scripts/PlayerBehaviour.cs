using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float rotatespeed = 75f;

    public float distanceToGround = 0.1f;
    public float jumpVelocity = 5f; 

    private float vInput;
    private float hInput;

    private Rigidbody rigidbody;

    public LayerMask groundLayer;

    private CapsuleCollider _col;

    public GameObject bullet;

    GameObject newBullet;

    public float bulletSpeed = 100f;

    public EnemyBehaviour enemy;

    public GameBehaviour gameBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();

        _col = GetComponent<CapsuleCollider>();

        gameBehaviour = gameBehaviour.GetComponent<GameBehaviour>(); 
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * movementSpeed;
        hInput = Input.GetAxis("Horizontal") * rotatespeed;

        if (Input.GetMouseButtonDown(0))
        {
            newBullet = Instantiate(bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation) as GameObject;
            
            Rigidbody bulletRigid = newBullet.GetComponent<Rigidbody>();
            
            bulletRigid.velocity = this.transform.forward * bulletSpeed;

        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidbody.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }

    }
    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        rigidbody.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);

        rigidbody.MoveRotation(rigidbody.rotation * angleRot);
    }

    bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {       
            gameBehaviour.PlayerHP = gameBehaviour.PlayerHP - enemy.damage;
            this.CheckHealth(gameBehaviour.PlayerHP);
        }
    }

    public void CheckHealth(int remainingHealth)
    {
        Debug.Log("Player Health remaining:" + remainingHealth);
        if (remainingHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
