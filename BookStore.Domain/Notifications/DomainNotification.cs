namespace BookStore.Domain.Notifications
{
    public class DomainNotification
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public DomainNotification(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
