namespace rainfall.domain.ViewModel
{
    public class FloodArea
    {
        public string Id { get; set; }
        public string County { get; set; }
        public string CurrentWarning { get; set; }
        public string Description { get; set; }
        public string EaAreaName { get; set; }
        public Envelope Envelope { get; set; }
        public string FwdCode { get; set; }
        public string Label { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Notation { get; set; }
        public string Polygon { get; set; }
        public string QuickDialNumber { get; set; }
        public string RiverOrSea { get; set; }
        public string[] Type { get; set; }
    }
}
