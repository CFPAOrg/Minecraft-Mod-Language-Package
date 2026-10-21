using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace Packer.Core.Tests;

/// <summary>
/// 内存虚拟文件系统，实现 <see cref="IFileProvider"/>。
/// 用于不依赖真实磁盘的单元测试。
/// </summary>
public class InMemoryFileProvider : IFileProvider
{
    private readonly Dictionary<string, byte[]> _files = new(StringComparer.OrdinalIgnoreCase);
    private readonly HashSet<string> _dirs = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>添加一个虚拟文件</summary>
    public void AddFile(string path, string content)
    {
        path = Normalize(path);
        _files[path] = System.Text.Encoding.UTF8.GetBytes(content);
        // 注册所有父目录
        var parts = path.Split('/');
        for (int i = 1; i < parts.Length; i++)
        {
            var dir = string.Join("/", parts, 0, i);
            _dirs.Add(dir);
        }
    }

    public IFileInfo GetFileInfo(string subpath)
    {
        subpath = Normalize(subpath);
        if (_files.TryGetValue(subpath, out var data))
            return new InMemoryFile(Path.GetFileName(subpath), data, false);
        return new InMemoryFile(Path.GetFileName(subpath), null, true);
    }

    public IDirectoryContents GetDirectoryContents(string subpath)
    {
        subpath = Normalize(subpath);
        var prefix = string.IsNullOrEmpty(subpath) ? "" : subpath + "/";
        var files = _files.Keys
            .Where(k => k.StartsWith(prefix) && k.LastIndexOf('/') == prefix.Length - 1)
            .Select(k => new InMemoryFile(Path.GetFileName(k), _files[k], false));
        var dirs = _dirs
            .Where(d => d.StartsWith(prefix) && d.Length > prefix.Length && !d[prefix.Length..].Contains('/'))
            .Select(d => new InMemoryFile(d[(prefix.Length)..], null, false) { IsDirectory = true });
        return new InMemoryDirectoryContents(files.Concat(dirs));
    }

    public IChangeToken Watch(string filter) => NullChangeToken.Singleton;

    private static string Normalize(string path)
        => path.Replace('\\', '/').TrimStart('/');
}

internal class InMemoryFile : IFileInfo
{
    private readonly byte[]? _data;
    public bool Exists => _data is not null;
    public long Length => _data?.Length ?? -1;
    public string? PhysicalPath => null;
    public string Name { get; }
    public DateTimeOffset LastModified => DateTimeOffset.MinValue;
    public bool IsDirectory { get; init; }

    public InMemoryFile(string name, byte[]? data, bool notExists)
    {
        Name = name;
        _data = notExists ? null : data;
    }

    public Stream CreateReadStream()
        => _data is not null ? new MemoryStream(_data) : Stream.Null;
}

internal class InMemoryDirectoryContents(IEnumerable<IFileInfo> contents) : IDirectoryContents
{
    public bool Exists => true;
    public IEnumerator<IFileInfo> GetEnumerator() => contents.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}
