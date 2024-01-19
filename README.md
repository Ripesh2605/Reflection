# Reflection
Reflection in C# is a powerful feature that allows us to inspect and interact with types(classes, interfaces, enums, etc.) at runtime. It provides the ability to dynamically discover information about types, instantiate objects, and invoke methods or access properties, fields, and events. Reflection enables us to work with types and object in a flexible manner.

### Key aspect of reflection in C#
1. Loading Assemblies:
2. Accessing Types:
3. Inspecting Members:
4. Creating Instances:
5. Invoking Methods and Properties:

Common use of reflections include serialization, deserialization, dependency injection, plugin systems and extensiblity,and framework that require dynamic discovery of types.

## Overview of the console application craeted
This simple console application demonstrates the use of reflection in C# to analyze the structure of a dynamically loaded DLL. The program extracts information about the assembly, namespaces, and methods within those namespaces and exports the details as a JSON object.

### The program uses reflection to:
1. Dynamically load the specified DLL.
2. Extract information about the assembly, namespaces and methods.
3. Serialize the information into a JSON object using the Newtonsoft.Json library.
4. Display the JSON content ont the console.
5. Save the JSON to a file and display location of the file where it is stored.
