namespace FEEAssignment.Models
{
    using System;

    public class Feature
    {
    public string FeatureName { get; set; }
    public string Description { get; set; }
    public bool IsEnabled { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    }
}
