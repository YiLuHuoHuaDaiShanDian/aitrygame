using UnityEngine;

public class Mine : Building
{
    public int productionAmount = 5;

    protected override void Produce()
    {
        ResourceManager.Instance.Add(productionAmount);
    }
}
