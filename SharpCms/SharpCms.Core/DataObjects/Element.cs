using System;
using System.Collections.Generic;

namespace SharpCms.Core.DataObjects
{
    public class Element
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ElementTypeId { get; set; }
        public string ElementTypeName { get; set; }
        public Guid MacroId { get; set; }
        public string MacroName { get; set; }
        public IEnumerable<Parameter> Parameters { get; set; }
        public bool Published { get; set; }
    }

    public class ElementType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Parameter> Parameters { get; set; }
        public IEnumerable<Macro> Macros { get; set; } 
    }

    public class Parameter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public Type Type { get; set; }
    }

    public class Macro
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Scriptname { get; set; }
    }
}