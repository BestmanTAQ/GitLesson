namespace Scripts.DelegateEvent
{
    public interface IPerson
    {
        // Person.Died OnDied;         // экземпляр делегата нельзя объявить в интерфейсе, а событие можно
        event Person.Died Ondied2;
        
        // float _field;               // поля нельзя, а свойства можно
        float Field { get; set; }
    }
}