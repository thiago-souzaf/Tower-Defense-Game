using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager Instance { get; private set; }

    public GameObject standardTurretPrefab;
    public GameObject turretToBuild {  get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than 1 instance of build manager.");
            return;
        }
        Instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

}
