using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 20;
    public float coinDuration = 10f;
    private float warningTime = 4f;
    private float timeAlive;
    private bool isDespawning;
    private bool collected;

    public MeshRenderer coinMesh;

    public GameObject collectFX;

    private void Start()
    {
        SetRandomRotation();
        timeAlive = 0;
        isDespawning = false;
        collected = false;
        collectFX.SetActive(false);
    }

    private void Update()
    {
        timeAlive += Time.deltaTime;
        if ((timeAlive > coinDuration - warningTime) && !isDespawning)
        {
            isDespawning = true;
            StartCoroutine(StartDespawn());
        }
    }

    IEnumerator StartDespawn()
    {
        while(timeAlive < coinDuration)
        {
            coinMesh.enabled = !coinMesh.enabled;
            yield return new WaitForSeconds(0.2f);
            if (collected)
            {
                yield break;
            }
        }
        Destroy(gameObject);
    }

    [ContextMenu("collect coin")]
    public void Collect()
    {
        GetComponent<BoxCollider>().enabled = false;
        PlayerStats playerStats = SelectionManager.Instance.GetComponent<PlayerStats>();
        playerStats.Money += coinValue;

        coinMesh.enabled = false;
        collectFX.SetActive(true);
        Destroy(gameObject, 1f);
    }

    public void SetRandomRotation()
    {
        float rotationOnYAxis = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(new Vector3(0, rotationOnYAxis, 0));
    }

    private void OnMouseEnter()
    {
        collected = true;
        Collect();
    }
}
