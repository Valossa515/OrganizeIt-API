namespace OrganizeIt.API.Shared
{
    public record ApplicationConfig
    {
        public Loggin ApplicationInsights { get; init; }

        public ConnectionStrings ConnectionStrings { get; init; }

        public string[]? CorsOrigins { get; init; }

        public ApplicationConfig()
        {
            ApplicationInsights = new Loggin();
            ConnectionStrings = new ConnectionStrings();
        }
    }

    public record Loggin
    {
        public string? ConnectionString { get; init; }
    }

    public record ConnectionStrings
    {
        public string? DefaultConnection { get; init; }

        public string? DatabaseName { get; init; }
    }
}