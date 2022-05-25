namespace LifeMoney.Domain
{
    public interface IRecorder
    {
        IEnumerable<Record> Ins { get; }

        IEnumerable<Record> Outs { get; }        

        void CalculateBalance();
                
        decimal Balance { get; }
    }
}
