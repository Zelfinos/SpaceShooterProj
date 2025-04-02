using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Inputs : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private Transform myTransform;

    [SerializeField]
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
    private Quaternion originalRotation;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D rb2D = Player.GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(Down))
        {
            //Debug.Log("Joueur se déplace vers le bas");
            //myTransform.Translate(Vector3.down * coeffMove * Time.deltaTime);
            rb2D.MovePosition(rb2D.position + Vector2.down * coeffMove * Time.deltaTime);
            ThrustersOn();
            animator.Play("Idle");
        }
        
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(Up))
        {
            Debug.Log("Joueur se déplace vers le haut");
            //ChangeSprite(straight);
            //myTransform.Translate(Vector3.up * coeffMove * Time.deltaTime);
            rb2D.MovePosition(rb2D.position + Vector2.up * coeffMove * Time.deltaTime);
            ThrustersOn();
            animator.Play("Idle");
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(Right))
        {
            //ChangeSprite(right);
            Debug.Log("Joueur se déplace vers la droite");
            //myTransform.Translate(Vector3.right * coeffMove * Time.deltaTime);
            rb2D.MovePosition(rb2D.position + Vector2.right * coeffMove * Time.deltaTime);
            rb2D.MoveRotation(- coeffRot * Time.deltaTime);
            ThrustersOn();
            animator.Play("AnimationDroite");
        }

        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(Left))
        {
            //ChangeSprite(left);
            Debug.Log("Joueur se déplace vers la gauche");
            rb2D.MovePosition(rb2D.position + Vector2.left * coeffMove * Time.deltaTime);
            //myTransform.Translate(Vector3.left * coeffMove * Time.deltaTime);
            rb2D.MoveRotation(coeffRot * Time.deltaTime);
            ThrustersOn();
            animator.Play("AnimationGauche");
        }

        else
        {
            //ChangeSprite(straight);
            ThrustersOff();
            animator.Play("Idle");
        }


        /*if (myTransform.rotation != originalRotation)
        {
            if (myTransform.rotation.z < 0 && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(Left))
            {
               myTransform.Rotate(0, 0, coeffRot * Time.deltaTime);
            }
            if (myTransform.rotation.z > 0 && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(Right))
            {
                myTransform.Rotate(0, 0, -coeffRot * Time.deltaTime);
            }
        }*/
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
