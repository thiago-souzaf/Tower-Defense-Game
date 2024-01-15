using UnityEngine;

public class PathDirection : MonoBehaviour
{
	public ParticleSystem startPathArrows;
	public ParticleSystem endPathArrows;

    private void Start()
    {
        startPathArrows.Play();
        endPathArrows.Play();
    }

    public void HideArrows()
    {
        startPathArrows.Stop();
        endPathArrows.Stop();
    }
}
