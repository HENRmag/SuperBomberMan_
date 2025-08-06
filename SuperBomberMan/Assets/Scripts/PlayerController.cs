using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    float speed = 5.0f;

    public bool dead = false;

    public GameObject bombPrefab;

    private CharacterController characterController;
    private Animator animator;

    private Vector3 inputs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveMentPlayer();
        SpawnBomb();
    }
    void MoveMentPlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Verifica se o personagem está tentando mover-se na diagonal
        if (horizontal == vertical)
        {
            inputs = Vector3.zero;
        }
        else if (horizontal != 0 )
        {
            inputs.Set(horizontal, 0, 0);
        }
        else if (vertical != 0)
        {
            inputs.Set(0, 0, vertical);
        }

        characterController.Move(inputs * speed * Time.deltaTime);

        if (inputs != Vector3.zero)
        {
            animator.SetBool("andando", true);
            animator.Play("Andando");
            transform.forward = inputs;
        }
        else
        {
            animator.SetBool("andando", false);
            animator.Play("Parado");
        }
    }
    void SpawnBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(transform.position.x), bombPrefab.transform.position.y, Mathf.RoundToInt(transform.position.z)), bombPrefab.transform.rotation);
        }
    }
}
