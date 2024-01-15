using UnityEngine;

public class Screenshot : MonoBehaviour
{
    [Header("Screenshot settings")]
    public string path = "/Assets/Screenshots/";
    public string filePrefix = "Screenshot_";
    public string fileExtension = "jpg";
    public KeyCode keyToScreenshot = KeyCode.K;

    [Space]
    public float timeScaleChangeRate = 0.2f;

    // Index to put on file name
    private int index;

    // Name of the key in player prefs file
    private string fileKey;

    private void Start()
    {
        fileKey = filePrefix + "_index";
    }
    void Update()
    {
        if (Input.GetKeyDown(keyToScreenshot))
        {
            TakeScreenshot();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Makes the time go faster
            ScaleTime(true);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Makes the time go slower
            ScaleTime(false);
        }

    }

    void TakeScreenshot()
    {
        index = PlayerPrefs.GetInt(fileKey, 0);
        string fileName = filePrefix + index + "." + fileExtension;
        PlayerPrefs.SetInt(fileKey, index+1);
        ScreenCapture.CaptureScreenshot(path + fileName);
        Debug.Log("A screenshot was taken!");
    }

    void ScaleTime(bool makeFaster)
    {
        float amount = makeFaster ? timeScaleChangeRate : -timeScaleChangeRate;
        float newTime = Time.timeScale + amount;
        Time.timeScale = Mathf.Clamp(newTime, 0f, 1f);
        Debug.Log("Time Scale is set to: " + Time.timeScale);
    }
}
