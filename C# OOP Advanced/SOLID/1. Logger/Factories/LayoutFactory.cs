using System;
using System.Linq;
using System.Reflection;

public  class LayoutFactory
{
    public ILayout GetInstance(string typeLayout)
    {
        Type layoutType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == typeLayout);

        return (ILayout) Activator.CreateInstance(layoutType);
    }
}

