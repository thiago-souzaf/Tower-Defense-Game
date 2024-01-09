using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneFader : MonoBehaviour
{
	public Image img;
    public AnimationCurve curve;
    public float fadeTime;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string sceneToLoad)
    {
        StartCoroutine(FadeOut(sceneToLoad));
    }

    /// <summary>
    /// Makes the black screen invisible
    /// </summary>
    IEnumerator FadeIn()
    {
        float t = fadeTime;
        while (t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t / fadeTime);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    /// <summary>
    /// Makes the black screen visible
    /// </summary>
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t / fadeTime);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
