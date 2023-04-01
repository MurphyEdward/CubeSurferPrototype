using System.Collections.Generic;
using UnityEngine;
public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Transform _wasteContainer;
    private CubePicker _cubePicker;
    private void Awake()
    {
        _cubePicker = GetComponent<CubePicker>();
    }
    
    private List<CubePickup> _stackedCubes = new List<CubePickup>();
    public List<CubePickup> StackedCubes
    {
        get
        {
            return new List<CubePickup>(_stackedCubes);
        }

        private set
        {
            _stackedCubes = value;
        }
    }
    public int CurrentStackCubesNumber { get; private set; } = 1;
    public int TotalScore { get; private set; }

    public void StackCube(CubePickup cube)
    {
        _stackedCubes.Add(cube);
        cube.IsStacked = true;
        AddTotalScore();
    }

    public void UpdateCurrentStackCount()
    {
        CurrentStackCubesNumber = _stackedCubes.Count + 1;
    }

    private void AddTotalScore()
    {
        TotalScore++;
    }

    public void RemoveStackedCube(CubePickup cubePickup)
    {
        cubePickup.transform.SetParent(_wasteContainer);
        _stackedCubes.Remove(cubePickup);
    }
}
