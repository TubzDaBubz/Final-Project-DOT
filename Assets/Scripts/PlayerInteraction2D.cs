using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("NPC") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacted with " + other.name);
        }
    }
}