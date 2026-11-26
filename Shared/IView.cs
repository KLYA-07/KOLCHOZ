namespace Shared
{
    public interface IView
    {
        event EventHandler<FarmerInfoEventArgs> AddFarmerEvent;
        event EventHandler<FarmerIDEventArgs> RemoveFarmerEvent;
        event EventHandler<FarmerInfoEventArgs> UpdateFarmerEvent;
        event EventHandler<FarmerIDEventArgs> ReadFarmerEvent;
        event EventHandler<ExchangeEventArgs> ExchangeEvent;
        event EventHandler<FarmTypeEventArgs> FarmTypeEvent;

        public void ShowFarmers(IReadOnlyList<FarmerDTO> farmers);
    }
}
