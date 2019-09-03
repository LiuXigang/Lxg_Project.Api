using Project.API.Application.Commands;
using System;

namespace Project.API
{
    public static class MyConfigure
    {
        public static Type[] HandlerAssemblyMarkerTypes()
        {
            return new Type[] {
                typeof(CreateProjectCommandHandler),
                typeof(JoinProjectCommandHandler),
                typeof(ViewProjectCommandHandler)
            };
        }
    }
}
