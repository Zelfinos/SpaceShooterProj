using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Inputs : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private Transform myTransform;

    private GameObject Thrusters;

    [SerializeField]
    private float coeffRot;

    [SerializeField]
    private float coeffMove = 0f;

    [SerializeField]
    private AnimationCurve mvtCurve;

    [SerializeField]
    private KeyCode Up;
    [SerializeField]
    private KeyCode Down;
    [SerializeField]
    private KeyCode Left;
    [SerializeField]
    private KeyCode Right;

    [SerializeField]
    private Vector3 turnAngle;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private Transform transformSprite;
    private Animator animator;

    private Rigidbody2D rb2D;


    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animator = spriteRenderer.GetComponent<Animator>();
        transformSprite = spriteRenderer.GetComponent<Transform>();
        Thrusters = GameObject.Find("Thrusters");
    }

    void FixedUpdate()
    {
        ThrustersOff();

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(Down))
        {
            rb2D.MovePosition(rb2D.position + Vector2.down * coeffMove * Time.deltaTime);
            ThrustersOn();
            animator.Play("Idle");
        }
        
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(Up))
        {
            rb2D.MovePosition(rb2D.position + Vector2.up * coeffMove * Time.deltaTime);
            ThrustersOn();
            animator.Play("Idle");
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(Right))
        {
            rb2D.MovePosition(rb2D.position + Vector2.right * coeffMove * Time.deltaTime);
            ThrustersOn();
            transformSprite.Rotate(-turnAngle);
            animator.Play("AnimationDroite");
        }

        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(Left))
        {
            rb2D.MovePosition(rb2D.position + Vector2.left * coeffMove * Time.deltaTime);
            ThrustersOn();
            transformSprite.Rotate(turnAngle);
            animator.Play("AnimationGauche");
        }

        else
        {
            animator.Play("Idle");
            if (transformSprite.rotation.z < 0)
            {
                transformSprite.Rotate(turnAngle * 2);
            }
            else if (transformSprite.rotation.z > 0)
            {
                transformSprite.Rotate(-turnAngle * 2);
            }
        }
    }

    void ThrustersOff()
    {
        Thrusters.SetActive(false);
    }
    void ThrustersOn()
    {
        Thrusters.SetActive(true);
    }

}
