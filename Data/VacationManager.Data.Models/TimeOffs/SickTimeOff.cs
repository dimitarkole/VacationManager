namespace VacationManager.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class SickTimeOff : BaseTimeOff
    {
        public string AttachmentPath { get; set; }

        [NotMapped]
        public override bool IsHalfDay { get; set; }
    }
}
