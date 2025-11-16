namespace Runtime.Domains.Common.Hits
{
    public interface IHittable
    {
        void Hit(ref HitContext context);
    }
}