namespace LifeMoney.Domain.Horology
{    
    public abstract class SpaceTime
    {
        public static SpaceTime This = new EarthSixOneSix();

        public static async void ReturnHome()
        {
            This = new EarthSixOneSix();
            
        }

        public abstract DateTime Today { get; }

        public abstract DateTime Now { get; }

        public abstract DateTime UtcNow { get; }
    }

    public class EarthSixOneSix : SpaceTime
    {
        public override DateTime Today => DateTime.Today; 

        public override DateTime Now => DateTime.Now;

        public override DateTime UtcNow => DateTime.UtcNow;
    }
}
