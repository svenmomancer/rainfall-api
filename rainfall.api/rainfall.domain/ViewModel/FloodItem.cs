namespace rainfall.domain.ViewModel
{
    public class FloodItem
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string EaAreaName { get; set; }
        public string EaRegionName { get; set; }
        public FloodArea FloodArea { get; set; }
        public string FloodAreaId { get; set; }
        public bool IsTidal { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; }
        public int SeverityLevel { get; set; }
        public DateTime TimeMessageChanged { get; set; }
        public DateTime TimeRaised { get; set; }
        public DateTime TimeSeverityChanged { get; set; }
        public string Type { get; set; }
    }
}
