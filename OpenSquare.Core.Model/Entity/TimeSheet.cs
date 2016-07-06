using System;

namespace OpenSquare.Core.Model.Entity
{
    public class TimeSheet
    {
        public DateTime IniDay { get; set; }
        public DateTime EndDay { get; set; }
        public DateTime BreakFestIni { get; set; }
        public DateTime BreakFestEnd { get; set; }
        public DateTime ExtendInit { get; set; }
        public DateTime ExtendEnd { get; set; }
        public long CliendId { get; set; }
        public long UserId { get; set; }
        public long ProjectId { get; set; }
        public string Comments { get; set; }
    }
}
