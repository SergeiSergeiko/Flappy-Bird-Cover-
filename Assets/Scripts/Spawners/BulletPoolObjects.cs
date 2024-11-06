using System.Linq;

public class BulletPoolObjects : GenericPoolObjects<Bullet>
{
    public override void Reset()
    {
        Objects?.Where(obj => obj.gameObject.activeSelf == true)
            .ToList()
            .ForEach(obj => obj.Remove());
    }
}