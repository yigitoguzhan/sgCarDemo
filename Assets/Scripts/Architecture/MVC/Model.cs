public abstract class Model
{

}

public abstract class Model<TData> where TData : ModelData
{
    public TData Data { get; private set; }

    public Model(TData data)
    {
        Data = data;
    }
}

public abstract class ModelData
{

}