namespace RealState.Domain.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Owner
    {
        public Guid IdOwner { get; set; }
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
