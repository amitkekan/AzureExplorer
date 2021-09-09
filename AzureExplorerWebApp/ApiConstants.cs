namespace AzureExplorerWebApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ApiConstants
    {
        public const string ApiUrlFormat = "http://gateway.marvel.com/v1/public/{0}?ts={1}&apikey={2}&hash={3}";

        public const string Characters = "characters";

        public const string Comics = "comics";

        public const string Creators = "creators";

        public const string Events = "events";

        public const string Series = "series";

        public const string Stories = "stories";
    }
}
