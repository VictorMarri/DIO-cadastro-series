namespace DIO.Serires.Entities.BaseEntity
{
    public abstract class EntidadeBase
    {
        //Todos qeu herdarem dessa classe deverao ter ID por default
        public int Id { get; protected set; }
    }
}
