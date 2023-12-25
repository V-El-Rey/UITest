using System.Collections.Generic;

public interface IDataDescriprionContext
{
    Dictionary<string, IDataContext<IDataDescription>> dataContextsPaths { get; set; }
}
