using System.Linq;

public class SmallEnemyPoolObjects : GenericPoolObjects<SmallEnemy>
{
    public override void Reset()
    {
        Objects?.Where(obj => obj.gameObject.activeSelf == true)
            .ToList()
            .ForEach(obj => obj.Remove());
    }
}