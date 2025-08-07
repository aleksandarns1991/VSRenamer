using System.Diagnostics;

namespace VsRenamer.Logic
{
    public class ProjectRenamer
    {
        public string? ProjectPath { get; set; }
        public string? ProjectName { get; set; }
        public string? NewName { get; set; }
        public bool RenameParent { get; set; }

        public async Task RenameProjectAsync()
        {
            var files = Directory.EnumerateFiles(ProjectPath!, "*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                try
                {
                    await TryRewritingFileAsync(file);
                    TryRenamingFile(file);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            var directories = Directory.EnumerateDirectories(ProjectPath!, "*", SearchOption.AllDirectories).OrderByDescending(d => d.Length);

            foreach (var directory in directories)
            {
                try
                {
                    var dirName = Path.GetFileName(directory);

                    if (dirName == "bin" || dirName == "obj")
                    {
                        Directory.Delete(directory, true);
                        continue;
                    }

                    TryRenamingDirectory(directory);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public void RenameParentDirectory()
        {
            try
            {
                var parent = Directory.GetParent(ProjectPath!)!.FullName;
                var newDir = Path.Combine(parent, NewName!);

                Directory.Move(ProjectPath!, newDir);
                ProjectPath = newDir;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void RemoveVsDirectory()
        {
            try
            {
                var vs = Path.Combine(ProjectPath!, ".vs");

                if (Directory.Exists(vs))
                {
                    var dirInfo = new DirectoryInfo(vs);
                    dirInfo.Attributes &= ~FileAttributes.Hidden;
                    dirInfo.Delete(true);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public bool HasProjectFile()
        {
            var extensions = new string[] { ".csproj", ".sln" };
            var files = Directory.EnumerateFiles(ProjectPath!, "*", SearchOption.AllDirectories);
            return files.Any(f => extensions.Contains(Path.GetExtension(f)) && Path.GetFileNameWithoutExtension(f) == ProjectName);
        }

        private async Task TryRewritingFileAsync(string file)
        {
            var content = await ReadFileAsync(file);

            if (content.Contains(ProjectName!))
            {
                content = content.Replace(ProjectName!, NewName!);
                await WriteToFileAsync(file, content);
            }
        }

        private void TryRenamingFile(string file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file);

            if (fileName.Contains(ProjectName!))
            {
                var parent = Directory.GetParent(file)!.FullName;
                var name = fileName.Replace(ProjectName!, NewName);
                var extension = Path.GetExtension(file);
                var newFile = Path.Combine(parent, $"{name}{extension}");

                File.Move(file, newFile);   
            }
        }

        private void TryRenamingDirectory(string dir)
        {
            var name = Path.GetFileName(dir);

            if (name.Contains(ProjectName!))
            {
                var parent = Directory.GetParent(dir)!.FullName;
                var dirName = name.Replace(ProjectName!, NewName);
                var newDir = Path.Combine(parent, dirName);

                Directory.Move(dir, newDir);
            }
        }

        private async Task WriteToFileAsync(string path, string content)
        {
            using var writer = new StreamWriter(path);
            await writer.WriteAsync(content);
        }

        private async Task<string> ReadFileAsync(string path)
        {
            using var reader = new StreamReader(path);
            return await reader.ReadToEndAsync();
        }
    }
}