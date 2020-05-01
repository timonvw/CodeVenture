using System.Runtime.CompilerServices;
using UnityEngine;
using CodeVenture;

namespace CodeVenture
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]private float moveSpeed;
        private Animator anim;
        private bool accesEditor = false;

        [SerializeField]private GameObject editText;

        // Use this for initialization
        private void Start ()
        {
            anim = this.GetComponent<Animator>();
        }
	
        // Update is called once per frame
        private void FixedUpdate ()
        {
            Move();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && accesEditor == true && GameManager.Instance.StopMovement == false)
            {
                UIHandler.Instance.OpenEditor(true);
            }
        }

        private void Move()
        {
            // Hardcode for life
            if (GameManager.Instance.StopMovement == false)
            {
                //Boven lopen
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(0,moveSpeed * Time.deltaTime,0);
                    anim.SetBool("up", true);
                    MusicManager.Instance.PlayWalkSound();
                }
                else
                {
                    anim.SetBool("up", false);
                    MusicManager.Instance.StopWalkSound();
                }
               
                //Ondere lopen
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
                    anim.SetBool("down", true);
                    MusicManager.Instance.PlayWalkSound();
                }
                else
                {
                    anim.SetBool("down", false);
                    MusicManager.Instance.StopWalkSound();
                }

                //Links lopen
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                    anim.SetBool("left", true);
                    MusicManager.Instance.PlayWalkSound();
                }
                else
                {
                    anim.SetBool("left", false);
                    MusicManager.Instance.StopWalkSound();
                }

                //Rechts lopen
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                    anim.SetBool("right", true);
                    MusicManager.Instance.PlayWalkSound();
                }
                else
                {
                    anim.SetBool("right", false);
                    MusicManager.Instance.StopWalkSound();
                }
            }
            else
            {
                anim.SetBool("up", false);
                anim.SetBool("down", false);
                anim.SetBool("left", false);
                anim.SetBool("right", false);
                MusicManager.Instance.StopWalkSound();
            }
        }

        // on trigger enter
        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "Editable" && GameManager.Instance.StopMovement == false)
            {
                editText.GetComponent<TextMesh>().text = "Druk op F om aan te passen";
                editText.GetComponentInChildren<TextMesh>().text = "Druk op F om aan te passen";

                editText.SetActive(true);
                ResetVelocity();
                UIHandler.Instance.EditableObject = coll.gameObject;
                accesEditor = true;
            }
        }

        private void OnTriggerExit2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "Editable" || coll.gameObject.tag == "Buddy")
            {
                editText.SetActive(false);
                accesEditor = false;
            }
        }

        //Resets de velocity
        private void ResetVelocity()
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
