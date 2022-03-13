namespace VacationManager.Web.ViewModels.TeamModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TeamsAllViewModel<T>
    {
        public IEnumerable<T> Teams { get; set; }

        public int NumberOfPages { get; set; }

        public int CurrentPage { get; set; }
    }
}
