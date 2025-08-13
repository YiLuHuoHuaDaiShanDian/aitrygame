using UnityEngine;

public class Mine : Building
{
    public int productionAmount = 5;

    public override string BuildingId => "Mine";

    protected override void Produce()
    {
        GameManager.Instance.AddResource("Gold", productionAmount);
    }
}
