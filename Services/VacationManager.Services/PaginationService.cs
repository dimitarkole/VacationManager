namespace VacationManager.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PaginationService : IPaginationService
    {
        private const string InvalidElementsPerPageErrorMessage = "Elements per page cannot be negative or zero number.";
        private const string InvalidElementsCountErrorMessage = "Elements count cannot be negative number.";

        public int CalculatePagesCount(int elementsCount, int elementsPerPage)
        {
            if (elementsPerPage <= 0)
            {
                throw new ArgumentException(InvalidElementsPerPageErrorMessage);
            }

            if (elementsCount < 0)
            {
                throw new ArgumentException(InvalidElementsCountErrorMessage);
            }

            return (int)Math.Ceiling((double)elementsCount / elementsPerPage);
        }
    }
}
