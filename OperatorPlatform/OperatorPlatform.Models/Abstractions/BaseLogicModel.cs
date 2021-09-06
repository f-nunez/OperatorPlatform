namespace OperatorPlatform.Models.Abstractions
{
    public abstract class BaseLogicModel : BaseModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
    }
}
