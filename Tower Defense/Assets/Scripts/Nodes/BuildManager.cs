using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager Instance { get; private set; }

    [Header("Optional")]
    [Tooltip("Turret to build is a Turret Blueprint instance that is set when the user selects a turret from the shop")]
    public TurretBlueprint turretToBuild;

    public bool HasTurretSelected {  get { return turretToBuild != null; }  }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than 1 instance of build manager.");
            return;
        }
        Instance = this;
        
    }

    public GameObject BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost){
            Debug.Log("Not enough money");
            return null;
        }
        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, node.PositionToBuild, Quaternion.identity);

        Debug.Log("Turret build, money left: " + PlayerStats.Money);
        return turret;
    }
}
