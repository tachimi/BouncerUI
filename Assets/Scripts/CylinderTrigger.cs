using UnityEngine;

public class CylinderTrigger : MonoBehaviour
{
    private GameController _gameController;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _gameController.DestroyCylinder(gameObject);
        }
    }
}
