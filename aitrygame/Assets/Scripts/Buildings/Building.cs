using UnityEngine;

public abstract class Building : MonoBehaviour
{
    [Header("Base Building Info")]
    public int constructionCost = 10;
    public float productionInterval = 5f;

    public Vector3 PlacementPosition { get; private set; }
    private float timer;

    public virtual void Place(Vector3 position)
    {
        PlacementPosition = position;
        transform.position = position;
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;
        if (timer >= productionInterval)
        {
            Produce();
            timer = 0f;
        }
    }

    protected abstract void Produce();
}
