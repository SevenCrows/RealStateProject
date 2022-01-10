namespace RealState.Domain.Model
{
    using System;
    public class PropertyTrace
    {
        public Guid IdPropertyTrace { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public decimal Tax { get; set; }
        public Guid IdProperty { get; set; }
    }
}
