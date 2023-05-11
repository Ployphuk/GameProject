using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rb;
	private BoxCollider2D colli;
	private SpriteRenderer sprite;
	private Animator anim;
	[SerializeField] private LayerMask jumableGround;
	private float dirX = 0;
	[SerializeField]private float moveSpeed = 7f;
	[SerializeField]private float jumpforce = 14f;
	
	private void Start(){
		rb = GetComponent<Rigidbody2D>();
		colli = GetComponent<BoxCollider2D>();
		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}

	private void Update(){
		//ขยับซ้ายขวา
		
		dirX = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

		//buttondown = กดครั้งเดียว ค้างไม่ได้ button เรียกจากinput manager
		//กระโดด
		if(Input.GetButtonDown("Jump") && IsGrounded()){
			rb.velocity = new Vector2(rb.velocity.x, jumpforce);
		}

		UpdateAnimation();
		
	}

	private void UpdateAnimation(){
		// dirx  = ขยับซ้ายขวา
		//animation
		if(dirX > 0f){
			anim.SetBool("run", true);
			sprite.flipX = false;
		}else if(dirX < 0f){
			anim.SetBool("run", true);
			sprite.flipX = true;

		}else{
			anim.SetBool("run",false);
		}
	}

	public bool canAttack(){
		return dirX == 0;
	}

	private bool IsGrounded(){
		return Physics2D.BoxCast(colli.bounds.center, colli.bounds.size, 0f, Vector2.down, .1f, jumableGround);
	}
	
}