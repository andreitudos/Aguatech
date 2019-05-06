namespace Aguatech.Web.Data.Entities
{
    public class Currency : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Simbol { get; set; }
    }
}
