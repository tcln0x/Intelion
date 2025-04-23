namespace Intelion.Modules.Username.Models
{
    public record UsernameTarget
    {
        public string Username { get; init; }

        public UsernameTarget(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));

            Username = username;
        }
    }
}