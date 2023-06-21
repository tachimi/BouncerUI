using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private GameObject _cylinderPrefab;
    [SerializeField] private GameObject _spherePrefab;

    [SerializeField] private Transform _cylindersParent;

    [SerializeField] private Vector3[] _borders;

    [SerializeField] private Color[] _colors;

    public int _redCylinders;
    public int _yellowCylinders;
    public int _greenCylinders;

    private GameObject _cube;


    private void Awake()
    {
        _cube = Instantiate(_cubePrefab);

        SpawnSphere();

        for (int i = 0; i < 6; i++)
        {
            var cylinder = Instantiate(_cylinderPrefab, _cylindersParent);
            
            cylinder.transform.position = new Vector3(Random.Range(_borders[0].x, _borders[1].x), 6,
                Random.Range(_borders[0].z, _borders[1].y));
            
            var randomColor = Random.Range(0, 3);
            cylinder.GetComponent<MeshRenderer>().material.color = _colors[randomColor];
            
            AddColor(randomColor);
        }
    }

    public void SpawnSphere()
    {
        var sphere = Instantiate(_spherePrefab);
        sphere.transform.position = new Vector3(Random.Range(-40, 40), 2, Random.Range(-40, 40));
        sphere.GetComponent<MeshRenderer>().material.color = _colors[Random.Range(0, 3)];
    }

    public void ChangeCubeColor(Color color)
    {
        _cube.GetComponent<MeshRenderer>().material.color = color;
    }

    public void DestroyCylinder(GameObject cylinder)
    {
        var cylinderColor = cylinder.GetComponent<MeshRenderer>().material.color;
        var cubeColor = _cube.GetComponent<MeshRenderer>().material.color;
        if (cubeColor == cylinderColor)
        {
            DeleteColor(cylinderColor);
            Destroy(cylinder);
        }
    }

    private void AddColor(int index)
    {
        switch (index)
        {
            case 0:
                _redCylinders++;
                break;
            case 1:
                _yellowCylinders++;
                break;
            case 2:
                _greenCylinders++;
                break;
        }
    }

    private void DeleteColor(Color color)
    {
        if (_colors[0] == color)
        {
            _redCylinders--;
        }
        else if (_colors[1] == color)
        {
            _yellowCylinders--;
        }
        else if(_colors[2] == color)
        {
            _greenCylinders--;
        }
    }
}