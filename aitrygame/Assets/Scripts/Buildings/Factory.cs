using UnityEngine;

public class Factory : Building
{
    public int productionAmount = 2;

    public override string BuildingId => "Factory";

    protected override void Produce()
    {
        GameManager.Instance.AddResource("Gold", productionAmount);
    }
}
