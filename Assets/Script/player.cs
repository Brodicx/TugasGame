using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float speed;
   private Rigidbody2D body;
   private Animator anim;
   private bool grounded;

   private void Awake()
   {
    body = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
   }

   private void Update()
   {
  float horizontalInput = Input.GetAxis("Horizontal");
body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

if (horizontalInput > 0.01f)
    transform.localScale = new Vector3(2, 2, 2);
else if (horizontalInput < -0.01f)
    transform.localScale = new Vector3(-2, 2, 2);


if(Input.GetKey(KeyCode.Space) && grounded)
    jump();
    
    anim.SetBool("run", horizontalInput != 0);
    anim.SetBool("grounded", grounded);
   }

   private void jump()
   {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
    if(collision.gameObject.tag == "Ground")
        grounded = true;
   }

   
}
