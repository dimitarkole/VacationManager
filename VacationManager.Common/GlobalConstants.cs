namespace VacationManager.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "Vacation Manager";
        public const int PaginationOffset = 5;
        public const int DefaultPage = 1;
        public const int DefaultItemPerPage = 10;
        public const string QueryStringDelimiter = "&";
        public const string PageKey = "page";
        public const string ItemsPerPageKey = "itemsPerPage";

        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string CEO = "CEO";
            public const string TeamLeader = "Team Lead";
            public const string Developer = "Developer";
            public const string Unassigned = "Unassigned";
        }
    }
}
