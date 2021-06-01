namespace GlobalKinetic.CoinJar.Framework.Interfaces
{
    public interface ICoinJar
    {
        void AddCoin(ICoin coin);
        decimal GetTotalAmount();
        void Reset();

        //I want to add the below methods also, but not sure if I'm allowed.
        //I had to remove the other methods on the interface as per the review of the app, comments were that it were not part of the requirement spec.
        //This interface now is exactly the same as per requirements.

        //decimal GetTotalVolume();
        //decimal GetJarMaxVolume();
    }
}
