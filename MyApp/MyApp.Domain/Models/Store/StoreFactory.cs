namespace MyApp.Domain.Models
{
    public class StoreFactory
    {
        private static readonly StoreFactory instance = new();

        static StoreFactory()
        {
        }

        private StoreFactory()
        {
        }

        public static StoreFactory Instance
        {
            get
            {
                return instance;
            }
        }

        internal Store CreateStore(string id)
        {
            return new Store(id);
        }

        public Store CreateStore(IStoreIDO ido)
        {
            // call "Anti-Corruption Layer"
            StoreACL.Check(ido);
            // if OK continue
            return new Store(ido);
        }
    }
}
