using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager Instance { get; private set; }

    public GameObject standardTurretPrefab;

    public GameObject anotherTurretPrefab;
    public GameObject turretToBuild {  get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than 1 instance of build manager.");
            return;
        }
        Instance = this;
        
    }

}
