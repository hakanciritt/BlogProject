namespace BlogUI.Security
{
    public interface ICurrentUser
    {
        int? UserId { get; }
        string Mail { get; }
        string Name { get; }
        string[] Roles { get; }
    }
}
