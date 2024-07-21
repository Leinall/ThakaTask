using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    List<Vector3> currentEnvironmentPositions = new List<Vector3>(); // it was meant for optimizing the ground generation later on
                                                                     // All shall be saved to avoid redunduncy

    // Start is called before the first frame update
    void Start()
    {

    }
    public bool AddEnvPosToList(Vector3 envPos)
    {
        if (!currentEnvironmentPositions.Contains(envPos))
        {
            currentEnvironmentPositions.Add(envPos);
            return true;
        }
        return false;
    }
}
