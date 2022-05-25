using LifeMoney.Domain.Horology;

namespace LifeMoney.Domain
{
    public class Record
    {
        public string? Description { get; set; }

        public IRecorder? Origin { get; set; }

        public IRecorder? Destiny { get; set; }

        public decimal Value { get; set; }

        public DateTime Reference { get; set; } = SpaceTime.This.Now;
    }
}