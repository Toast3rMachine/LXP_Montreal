using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Paramètres")]
    public float moveSpeed = 10f;

    private Rigidbody rb;
    private Vector2 moveDirection;

    void Start()
    {
        // Récupération ou ajout du Rigidbody
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();

        // Configuration du Rigidbody
        rb.useGravity = false;
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Appelé quand le joueur appuie sur une touche de mouvement
    public void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
        Debug.Log($"Touches pressées - Horizontal (Q/D): {moveDirection.x}, Vertical (Z/S): {moveDirection.y}");
    }

    void FixedUpdate()
    {
        // Conversion des inputs 2D en mouvement 3D selon la vue de la caméra
        Vector3 movement = new Vector3(
            moveDirection.x,    // Q/D : gauche/droite sur X
            0f,                 // Pas de mouvement vertical
            moveDirection.y     // Z/S : haut/bas sur Z
        );

        if (movement != Vector3.zero)
        {
            movement = movement.normalized;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            Debug.Log($"Position: {rb.position}, Mouvement: {movement}");
        }
    }
}