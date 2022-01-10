namespace RealState.Domain.Model
{
    using System;
    public class Property
    {
        public Guid IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public DateTime Year { get; set; }
        public Guid IdOwner { get; set; }
    }
}
