using UnityEngine;

public class House : Building
{
    public int population = 1;

    public override string BuildingId => "House";

    protected override void Produce()
    {
        GameManager.Instance.AddResource("Population", population);
    }
}
