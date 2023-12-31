﻿namespace ALTC_Website.Models
{
    public class AltcDatabaseSettings
    {
        public static object Value { get; internal set; }
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;
        public string Department { get; set; } = null!;

        public string TechnicalCollection { get; set; } = null!; 
        public string JobCandidateCollection3 { get; set; } = null!;
        public string StaticCollection3 { get; set; } = null!;
        public string RequestCollection { get; set; }=null!;
        public string ComplainCollection { get; set; }=null !;
        public string TeamCollection { get; set; } = null!;
        public string AccountCollection {  get; set; } = null!;
        public string ServiceCollection {  get; set; } = null!;
    }
}
