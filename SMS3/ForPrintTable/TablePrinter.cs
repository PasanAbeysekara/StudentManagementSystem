using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpBasics.TabularData
{
    public sealed class TablePrinter<TData> : IPrintTabularData<TData>
    {
        public void PrintTable(IEnumerable<TData> data)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            PropertyInfo[] propertyInfos = typeof(TData).GetProperties();
            var propertyNames = propertyInfos.Select(propInfo => propInfo.Name).ToArray();

            ConsoleDisplayFormatter.PrintSeperatorLine();
            ConsoleDisplayFormatter.PrintRow(propertyNames);
            ConsoleDisplayFormatter.PrintSeperatorLine();

            foreach (var datum in data)
            {
                var values = propertyInfos.Select(propInfo => propInfo.GetValue(datum, null).ToString()).ToArray();
                ConsoleDisplayFormatter.PrintRow(values);
            }

            ConsoleDisplayFormatter.PrintSeperatorLine();

            Console.ResetColor();
        }
    }
}
