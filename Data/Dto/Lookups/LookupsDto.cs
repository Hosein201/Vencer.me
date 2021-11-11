using System;

namespace Data.Dto.Lookups
{
    public class LookupsDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }
        public string Aux1 { get; set; }
        public string Aux2 { get; set; }
        public bool IsActive { get; set; }
    }

    public class LookupsWithCode
    {
        public string Type { get; set; }
        public int Code { get; set; }
        public string Aux1 { get; set; }
    }
    public class LookupsWithType
    {
        public string Type { get; set; }
    }

    public class LookupsWithoutCode
    {
        public string Type { get; set; }
        public string Aux1 { get; set; }
    }
    
}
