using Common.Utilities;
using System;

namespace Data.Dto.SupportExchanges
{
    public class UpdateSupportExchangesDto
    {
        public string State { get; set; }
        public string Description { get; set; }
        public Guid IdExchange { get; set; }
        public Guid UserId { get; set; }
    }

    public class ConfirmedFileSupportExchangesDto
    {
        public bool IsConfirmed { get; set; }
        public string State { get; set; }
        public Guid IdExchange { get; set; }
        public Guid UserId { get; set; }
    }
}
