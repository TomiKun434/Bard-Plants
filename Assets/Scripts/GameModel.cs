public class GameModel 
{
    public SubscriptionField<int> StarchNut { get; }
    public SubscriptionField<int> MysticalMushroom { get; }
    public SubscriptionField<int> CountCustomerInGame { get; }
    
    public GameModel()
    {
        StarchNut = new SubscriptionField<int>();
        MysticalMushroom = new SubscriptionField<int>();
        CountCustomerInGame = new SubscriptionField<int>();
    }
}
