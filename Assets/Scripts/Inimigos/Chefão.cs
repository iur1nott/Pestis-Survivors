using UnityEngine;
using System.Collections;

public class Chefão : MonoBehaviour
{
    [Header("Spawn-Scale Settings")]
    [Tooltip("Curve controlling scale over [0…1]")]
    [SerializeField] private AnimationCurve scaleCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [Tooltip("Scale at t=0")]
    [SerializeField] private Vector3 startScale = Vector3.zero;
    [Tooltip("Scale at t=1")]
    [SerializeField] private Vector3 normalScale = Vector3.one;
    [Tooltip("How long the scaling takes (seconds)")]
    [SerializeField] private float scaleDuration = 0.8f;
    
    [Header("Growth Settings")]
    [Tooltip("Final scale after spawn")]
    [SerializeField] private Vector3 endScale = new Vector3(1.5f, 1.5f, 1.5f);
    [Tooltip("Growth duration after spawn (seconds)")]
    [SerializeField] private float growthDuration = 5f;
    [Tooltip("Curve for post-spawn growth")]
    [SerializeField] private AnimationCurve growthCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private Animator animator;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        transform.localScale = startScale;
        StartCoroutine(ScaleUp());
        animator.Play("Chefao_spawn");
    }

    // Corrotina para crescimento inicial (spawn)
    private IEnumerator ScaleUp()
    {
        float elapsed = 0f;
        while (elapsed < scaleDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / scaleDuration);
            float eval = scaleCurve.Evaluate(t);
            transform.localScale = Vector3.LerpUnclamped(startScale, normalScale, eval);
            yield return null;
        }
        transform.localScale = normalScale;
    }

    // Corrotina para crescimento pós-spawn
    private IEnumerator GrowToEndScale()
    {
        Vector3 initialScale = transform.localScale;
        float elapsed = 0f;
        
        while (elapsed < growthDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / growthDuration);
            float eval = growthCurve.Evaluate(t);
            transform.localScale = Vector3.LerpUnclamped(initialScale, endScale, eval);
            yield return null;
        }
        
        transform.localScale = endScale;
    }

    // Chamado ao final da animação de spawn
    public void OnSpawnAnimationEnd()
    {
        Debug.Log("✔ OnSpawnAnimationEnd called!");
        animator.Play("Chefao");
        StartCoroutine(GrowToEndScale()); // Inicia o crescimento até a escala final
    }
}