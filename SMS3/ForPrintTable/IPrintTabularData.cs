using System.Collections.Generic;

namespace CSharpBasics.TabularData
{
    public interface IPrintTabularData<TData>
    {
        void PrintTable(IEnumerable<TData> data);
    }
}
