using System;
using System.Reflection;

namespace ProgramacionAvanzada_Proyecto_G2_API.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}