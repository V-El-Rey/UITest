public interface IDataContext<T>
{
    string id { get; set; } 

    void LoadData();
    T ReadData();
}
