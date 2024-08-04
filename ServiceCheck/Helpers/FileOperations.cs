using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ServiceCheck.Helpers
{
    public class FileOperations<T>
    {
        private string _filePath;

        public FileOperations(string filePath = "")
        {
            _filePath = filePath;
        }

        public void CreateFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    using (StreamWriter sw = File.CreateText(_filePath))
                    {
                        Console.WriteLine("File created.");
                    }
                }
                else
                {
                    Console.WriteLine("File already exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void WriteToFile(T data, bool append = false)
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("File does not exist.");
                    return;
                }

                if (IsDataExists(data))
                {
                    Console.WriteLine("Data already exists in the file.");
                    return;
                }

                using (StreamWriter sw = new StreamWriter(_filePath, append))
                {
                    sw.WriteLine(data.ToString());
                    Console.WriteLine("Data written to the file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public string ReadFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return "";
                }

                using (StreamReader sr = File.OpenText(_filePath))
                {
                    string line;
                    string text = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        text += line + Environment.NewLine;
                    }

                    return text;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return "";
            }
        }

        public void DeleteFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("File does not exist.");
                    return;
                }

                File.Delete(_filePath);
                Console.WriteLine("File deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void FindAndRemoveLine(T data)
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("File does not exist.");
                    return;
                }

                var lines = new List<string>();

                using (StreamReader sr = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!line.Trim().Equals(data.ToString().Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            lines.Add(line);
                        }
                    }
                }

                File.WriteAllLines(_filePath, lines);
                Console.WriteLine("Line removed from the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private bool IsDataExists(T data)
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return false;
                }

                using (StreamReader sr = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Trim().Equals(data.ToString().Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return false;
        }

        public static Dictionary<string, string> SearchFiles(string directory, string extension, string searchName = "")
        {
            if (string.IsNullOrWhiteSpace(directory) || string.IsNullOrWhiteSpace(extension))
            {
                Console.WriteLine("Dizin ve uzantı adı boş olamaz.");
            }

            if (!Directory.Exists(directory))
            {
                Console.WriteLine($"Belirtilen dizin bulunamadı: {directory}");
            }

            List<string> files = Directory.EnumerateFiles(directory, $"*{extension}", SearchOption.AllDirectories).ToList();

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                files = files.Where(file => Path.GetFileName(file).Contains(searchName)).ToList();
            }

            Dictionary<string, string> result = files.ToDictionary(
            file => Path.GetFileNameWithoutExtension(file),
            file => file
            );

            return result;
        }
    }
}
