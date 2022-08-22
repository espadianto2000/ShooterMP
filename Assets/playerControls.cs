using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    //private float rotVert = 0;
    float yRotate = 0;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    public bool flagGround = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {

        //neck.transform.localEulerAngles = new Vector3(180, 0, 31);
        Vector2 mouseInp = new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"));
        yRotate += mouseInp.y * Time.fixedDeltaTime * 75f;
        yRotate = Mathf.Clamp(yRotate, -50f, 50f);
        cam.transform.localEulerAngles = new Vector3(-yRotate, 0, 0);
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y+mouseInp.x*Time.fixedDeltaTime*50f,0);
        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        rb.MovePosition(transform.position + (transform.forward * vert * Time.fixedDeltaTime * 5) + (transform.right * hori * Time.fixedDeltaTime * 5));
        if(hori != 0 || vert != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking",false);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            animator.SetBool("isAiming", true);
            cam.GetComponent<Camera>().farClipPlane = 100;
            if (cam.GetComponent<Camera>().fieldOfView > 35)
            {
                cam.GetComponent<Camera>().fieldOfView -= 100 * Time.fixedDeltaTime;
                
            }
            else cam.GetComponent<Camera>().fieldOfView = 35;
        }
        else
        {
            animator.SetBool("isAiming", false);
            cam.GetComponent<Camera>().farClipPlane = 70;
            if (cam.GetComponent<Camera>().fieldOfView < 60)
            {
                cam.GetComponent<Camera>().fieldOfView += 100 * Time.fixedDeltaTime;
            }
            else cam.GetComponent<Camera>().fieldOfView = 60;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
        if (Input.GetKey(KeyCode.Space) && flagGround)
        {
            flagGround = false;
            rb.velocity = new Vector3(rb.velocity.x, 7.5f, rb.velocity.z);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (/*view.IsMine && */collision.transform.CompareTag("Untagged"))
        {
            flagGround = true;
        }
    }
    private void disparar()
    {
        RaycastHit hit;
        Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            Debug.Log(objectHit.name);
        }
    }
}
