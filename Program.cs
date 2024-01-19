using System.Reflection;

class Program
{
    static void Main()
    {
        /// <summary>
        /// This class is used to store information about the assembly, namespaces, and methods from DLL and serialize it to JSON.
        /// It then displays the JSON content on the console and saves it to a file.
        /// </summary>
        Console.Write("Enter the path to the DLL file: ");
        string dllPath = Console.ReadLine();

        try
        {
            // Loads the DLL dynamically
            Assembly assembly = Assembly.LoadFrom(dllPath);

            // Extract information about the assembly, namespaces, and methods
            var assemblyInfo = new
            {
                AssemblyName = assembly.GetName().Name,
                Namespaces = assembly.GetTypes()
                    .GroupBy(t => t.Namespace)
                    .Select(namespaceGroup => new
                    {
                        Namespace = namespaceGroup.Key,
                        Methods = namespaceGroup.SelectMany(type => type.GetMethods().Select(method => method.Name))
                    })
            };

            // Serializes the information to JSON
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(assemblyInfo, Newtonsoft.Json.Formatting.Indented);

            // Display the JSON content on the console
            Console.WriteLine("\nExported JSON Content:");
            Console.WriteLine(json);

            // Saves the JSON to a file
            string outputFileName = "exported_data.json";
            string outputPath = Path.Combine(Environment.CurrentDirectory, outputFileName);

            try
            {
                File.WriteAllText(outputPath, json);
                Console.WriteLine($"\nExported JSON saved to: {outputPath}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Error: Unauthorized access. You don't have permission to save the file at {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: DLL file not found at {dllPath}");
        }
        catch (BadImageFormatException)
        {
            Console.WriteLine($"Error: The format of the DLL file at {dllPath} is invalid or unsupported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
