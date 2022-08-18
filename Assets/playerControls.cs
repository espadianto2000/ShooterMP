using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    //private float rotVert = 0;
    float yRotate = 0;
    [SerializeField] private Animator animator;
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
    }
}
