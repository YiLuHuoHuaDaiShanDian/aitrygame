using UnityEngine;

public class Factory : Building
{
    public int productionAmount = 2;

    protected override void Produce()
    {
        ResourceManager.Instance.Add(productionAmount);
    }
}
