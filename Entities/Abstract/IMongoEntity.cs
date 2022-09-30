namespace Entities.Abstract
{
    public interface IMongoEntity : IEntity
    {
        public string Id { get; set; }
    }
}
