using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _redCylindersCount;
    [SerializeField] private TextMeshProUGUI _yellowCylindersCount;
    [SerializeField] private TextMeshProUGUI _greenCylindersCount;
    [SerializeField] private TextMeshProUGUI _cubeMovements;

    private CubeController _cubeController;
    private GameController _gameController;

    void Start()
    {
        _cubeController = FindObjectOfType<CubeController>();
        _gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_cubeMovements.text != _cubeController._numberOfMovements.ToString())
        {
            _cubeMovements.text = _cubeController._numberOfMovements.ToString();
        }

        _redCylindersCount.text = _gameController._redCylinders.ToString();
        _yellowCylindersCount.text = _gameController._yellowCylinders.ToString();
        _greenCylindersCount.text = _gameController._greenCylinders.ToString();

    }
}