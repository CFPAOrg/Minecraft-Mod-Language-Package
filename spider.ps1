$p = @"
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
public class Properties : Dictionary<string, string>
{
    private static readonly char[] HexDigit =
    {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'
        };

    protected Properties Defaults;

    public Properties() : this(null)
    {
    }

    public Properties(Properties defaults)
    {
        this.Defaults = defaults;
    }

    public void SetProperty(string key, string value)
    {
        this[key] = value;
    }

    public void Load(StreamReader reader)
    {
        Load0(new LineReader(reader));
    }

    public void Load(Stream inStream)
    {
        Load0(new LineReader(inStream));
    }

    private void Load0(LineReader lr)
    {
        var convtBuf = new char[1024];
        int limit;
        int keyLen;
        int valueStart;
        char c;
        bool hasSep;
        bool precedingBackslash;

        while ((limit = lr.ReadLine()) >= 0)
        {
            c = (char)0;
            keyLen = 0;
            valueStart = limit;
            hasSep = false;

            //System.out.println("line=<" + new String(lineBuf, 0, limit) + ">");
            precedingBackslash = false;
            while (keyLen < limit)
            {
                c = lr.LineBuf[keyLen];
                //need check if escaped.
                if ((c == '=' || c == ':') && !precedingBackslash)
                {
                    valueStart = keyLen + 1;
                    hasSep = true;
                    break;
                }

                if ((c == ' ' || c == '\t' || c == '\f') && !precedingBackslash)
                {
                    valueStart = keyLen + 1;
                    break;
                }

                if (c == '\\')
                    precedingBackslash = !precedingBackslash;
                else
                    precedingBackslash = false;

                keyLen++;
            }

            while (valueStart < limit)
            {
                c = lr.LineBuf[valueStart];
                if (c != ' ' && c != '\t' && c != '\f')
                {
                    if (!hasSep && (c == '=' || c == ':'))
                        hasSep = true;
                    else
                        break;
                }

                valueStart++;
            }

            var key = LoadConvert(lr.LineBuf, 0, keyLen, convtBuf);
            var value = LoadConvert(lr.LineBuf, valueStart, limit - valueStart, convtBuf);
            this[key] = value;
        }
    }

    /*
     * Converts encoded &#92;uxxxx to unicode chars
     * and changes special saved chars to their original forms
     */
    private string LoadConvert(char[] input, int off, int len, char[] convtBuf)
    {
        if (convtBuf.Length < len)
        {
            var newLen = len * 2;
            if (newLen < 0) newLen = int.MaxValue;

            convtBuf = new char[newLen];
        }

        char aChar;
        var output = convtBuf;
        var outLen = 0;
        var end = off + len;

        while (off < end)
        {
            aChar = input[off++];
            if (aChar == '\\')
            {
                aChar = input[off++];
                if (aChar == 'u')
                {
                    // Read the xxxx
                    var value = 0;
                    for (var i = 0; i < 4; i++)
                    {
                        aChar = input[off++];
                        value = aChar switch
                        {
                            '0' => ((value << 4) + aChar - '0'),
                            '1' => ((value << 4) + aChar - '0'),
                            '2' => ((value << 4) + aChar - '0'),
                            '3' => ((value << 4) + aChar - '0'),
                            '4' => ((value << 4) + aChar - '0'),
                            '5' => ((value << 4) + aChar - '0'),
                            '6' => ((value << 4) + aChar - '0'),
                            '7' => ((value << 4) + aChar - '0'),
                            '8' => ((value << 4) + aChar - '0'),
                            '9' => ((value << 4) + aChar - '0'),
                            'a' => ((value << 4) + 10 + aChar - 'a'),
                            'b' => ((value << 4) + 10 + aChar - 'a'),
                            'c' => ((value << 4) + 10 + aChar - 'a'),
                            'd' => ((value << 4) + 10 + aChar - 'a'),
                            'e' => ((value << 4) + 10 + aChar - 'a'),
                            'f' => ((value << 4) + 10 + aChar - 'a'),
                            'A' => ((value << 4) + 10 + aChar - 'A'),
                            'B' => ((value << 4) + 10 + aChar - 'A'),
                            'C' => ((value << 4) + 10 + aChar - 'A'),
                            'D' => ((value << 4) + 10 + aChar - 'A'),
                            'E' => ((value << 4) + 10 + aChar - 'A'),
                            'F' => ((value << 4) + 10 + aChar - 'A'),
                            _ => throw new ArgumentException("Malformed \\uxxxx encoding.")
                        };
                    }

                    output[outLen++] = (char)value;
                }
                else
                {
                    aChar = aChar switch
                    {
                        't' => '\t',
                        'r' => '\r',
                        'n' => '\n',
                        'f' => '\f',
                        _ => aChar
                    };
                    output[outLen++] = aChar;
                }
            }
            else
            {
                output[outLen++] = aChar;
            }
        }

        return new string(output, 0, outLen);
    }

    private string SaveConvert(string theString, bool escapeSpace, bool escapeUnicode)
    {
        var len = theString.Length;
        var bufLen = len * 2;
        if (bufLen < 0) bufLen = int.MaxValue;

        var outBuffer = new StringBuilder(bufLen);

        for (var x = 0; x < len; x++)
        {
            var aChar = theString[x];
            // Handle common case first, selecting largest block that
            // avoids the specials below
            if (aChar > 61 && aChar < 127)
            {
                if (aChar == '\\')
                {
                    outBuffer.Append('\\');
                    outBuffer.Append('\\');
                    continue;
                }

                outBuffer.Append(aChar);
                continue;
            }

            switch (aChar)
            {
                case ' ':
                    if (x == 0 || escapeSpace)
                        outBuffer.Append('\\');
                    outBuffer.Append(' ');
                    break;
                case '\t':
                    outBuffer.Append('\\');
                    outBuffer.Append('t');
                    break;
                case '\n':
                    outBuffer.Append('\\');
                    outBuffer.Append('n');
                    break;
                case '\r':
                    outBuffer.Append('\\');
                    outBuffer.Append('r');
                    break;
                case '\f':
                    outBuffer.Append('\\');
                    outBuffer.Append('f');
                    break;
                case '=': // Fall through
                case ':': // Fall through
                case '#': // Fall through
                case '!':
                    outBuffer.Append('\\');
                    outBuffer.Append(aChar);
                    break;
                default:
                    if ((aChar < 0x0020 || aChar > 0x007e) & escapeUnicode)
                    {
                        outBuffer.Append('\\');
                        outBuffer.Append('u');
                        outBuffer.Append(ToHex((aChar >> 12) & 0xF));
                        outBuffer.Append(ToHex((aChar >> 8) & 0xF));
                        outBuffer.Append(ToHex((aChar >> 4) & 0xF));
                        outBuffer.Append(ToHex(aChar & 0xF));
                    }
                    else
                    {
                        outBuffer.Append(aChar);
                    }

                    break;
            }
        }

        return outBuffer.ToString();
    }

    private static void WriteComments(StreamWriter bw, string comments)
    {
        bw.Write("#");
        var len = comments.Length;
        var current = 0;
        var last = 0;
        var uu = new char[6];
        uu[0] = '\\';
        uu[1] = 'u';
        while (current < len)
        {
            var c = comments[current];
            if (c > '\u00ff' || c == '\n' || c == '\r')
            {
                if (last != current)
                    bw.Write(comments.Substring(last, current));
                if (c > '\u00ff')
                {
                    uu[2] = ToHex((c >> 12) & 0xf);
                    uu[3] = ToHex((c >> 8) & 0xf);
                    uu[4] = ToHex((c >> 4) & 0xf);
                    uu[5] = ToHex(c & 0xf);
                    bw.Write(new string(uu));
                }
                else
                {
                    bw.WriteLine();
                    if (c == '\r' &&
                        current != len - 1 &&
                        comments[current + 1] == '\n')
                        current++;

                    if (current == len - 1 ||
                        comments[current + 1] != '#' &&
                        comments[current + 1] != '!')
                        bw.Write("#");
                }

                last = current + 1;
            }

            current++;
        }

        if (last != current)
            bw.Write(comments.Substring(last, current));
        bw.WriteLine();
    }

    [Obsolete]
    public void Save(Stream output, string comments)
    {
        try
        {
            Store(output, comments);
        }
        catch (IOException)
        {
        }
    }

    public void Store(StreamWriter writer, string comments)
    {
        Store0(writer, comments, false);
    }

    public void Store(Stream outStream, string comments)
    {
        Store0(new StreamWriter(outStream, Encoding.GetEncoding("8859_1")), comments, true);
    }

    private void Store0(StreamWriter bw, string comments, bool escUnicode)
    {
        if (comments != null) WriteComments(bw, comments);

        bw.Write("#" + new DateTime().ToString(CultureInfo.InvariantCulture));
        bw.WriteLine();
        //synchronized(this)
        //{
        foreach (var i in Keys)
        {
            var key = i as string;
            var val = this[key ?? throw new InvalidOperationException()] as string;
            key = SaveConvert(key, true, escUnicode);
            /* No need to escape embedded and trailing spaces for value, hence
         * pass false to flag.
         */
            val = SaveConvert(val, false, escUnicode);
            bw.Write(key + "=" + val);
            bw.WriteLine();
        }

        //}
        bw.Flush();
    }

    public string GetProperty(string key)
    {
        var oval = base[key];
        var sval = oval is string s ? s : null;
        return sval == null && Defaults != null ? Defaults.GetProperty(key) : sval;
    }

    public string GetProperty(string key, string defaultValue)
    {
        var val = GetProperty(key);
        return val ?? defaultValue;
    }
    public IEnumerable<string> PropertyNames()
    {
        var h = new Dictionary<string, object>();
        Enumerate(h);
        return h.Keys.ToList();
    }

    public HashSet<string> GetStringPropertyNames()
    {
        var h = new Dictionary<string, object>();
        EnumerateStringProperties(h);
        return h.Keys.ToHashSet();
    }

    private void Enumerate(IDictionary<string, object> h)
    {
        Defaults?.Enumerate(h);

        foreach (var i in Keys)
        {
            var key = (string)i;
            h[key] = this[key];
        }
    }
    private void EnumerateStringProperties(IDictionary<string, object> h)
    {
        Defaults?.EnumerateStringProperties(h);

        foreach (var i in Keys)
        {
            var k = i;
            var v = this[k];
            if (k is string s && v is string s1) h[s] = s1;
        }
    }

    private static char ToHex(int nibble)
    {
        return HexDigit[nibble & 0xF];
    }
    private class LineReader
    {
        private readonly byte[] _inByteBuf;
        private readonly char[] _inCharBuf;
        private int _inLimit;
        private int _inOff;
        private readonly Stream _inStream;
        public char[] LineBuf = new char[1024];
        private readonly StreamReader _reader;

        public LineReader(Stream inStream)
        {
            this._inStream = inStream;
            _inByteBuf = new byte[8192];
        }

        public LineReader(StreamReader reader)
        {
            this._reader = reader;
            _inCharBuf = new char[8192];
        }

        public int ReadLine()
        {
            var len = 0;

            var skipWhiteSpace = true;
            var isCommentLine = false;
            var isNewLine = true;
            var appendedLineBegin = false;
            var precedingBackslash = false;
            var skipLf = false;

            while (true)
            {
                if (_inOff >= _inLimit)
                {
                    _inLimit = _inStream?.Read(_inByteBuf) ?? _reader.Read(_inCharBuf);
                    _inOff = 0;
                    if (_inLimit <= 0)
                    {
                        if (len == 0 || isCommentLine) return -1;

                        if (precedingBackslash) len--;

                        return len;
                    }
                }

                char c;
                if (_inStream != null)
                    //The line below is equivalent to calling a
                    //ISO8859-1 decoder.
                    c = (char)(0xff & _inByteBuf[_inOff++]);
                else
                    c = _inCharBuf[_inOff++];

                if (skipLf)
                {
                    skipLf = false;
                    if (c == '\n') continue;
                }

                if (skipWhiteSpace)
                {
                    if (c == ' ' || c == '\t' || c == '\f') continue;

                    if (!appendedLineBegin && (c == '\r' || c == '\n')) continue;

                    skipWhiteSpace = false;
                    appendedLineBegin = false;
                }

                if (isNewLine)
                {
                    isNewLine = false;
                    if (c == '#' || c == '!')
                    {
                        isCommentLine = true;
                        continue;
                    }
                }

                if (c != '\n' && c != '\r')
                {
                    LineBuf[len++] = c;
                    if (len == LineBuf.Length)
                    {
                        var newLength = LineBuf.Length * 2;
                        if (newLength < 0) newLength = int.MaxValue;

                        var buf = new char[newLength];
                        Array.Copy(LineBuf, 0, buf, 0, LineBuf.Length);
                        LineBuf = buf;
                    }

                    //flip the preceding backslash flag
                    if (c == '\\')
                        precedingBackslash = !precedingBackslash;
                    else
                        precedingBackslash = false;
                }
                else
                {
                    // reached EOL
                    if (isCommentLine || len == 0)
                    {
                        isCommentLine = false;
                        isNewLine = true;
                        skipWhiteSpace = true;
                        len = 0;
                        continue;
                    }

                    if (_inOff >= _inLimit)
                    {
                        _inLimit = _inStream?.Read(_inByteBuf) ?? _reader.Read(_inCharBuf);
                        _inOff = 0;
                        if (_inLimit <= 0)
                        {
                            if (precedingBackslash) len--;

                            return len;
                        }
                    }

                    if (precedingBackslash)
                    {
                        len -= 1;
                        //skip the leading whitespace characters in following line
                        skipWhiteSpace = true;
                        appendedLineBegin = true;
                        precedingBackslash = false;
                        if (c == '\r') skipLf = true;
                    }
                    else
                    {
                        return len;
                    }
                }
            }
        }
    }
}
"@
Add-Type -TypeDefinition $p;
class LangType {
    static [LangType]$Json = [LangType]::new(".json");
    static [LangType]$Lang = [LangType]::new(".lang");
    [string]$Type;
    LangType([string]$type) {
        $this.Type = $type;
    }
    [bool]Equals([LangType]$obj){
        return $this.Type -eq $obj.Type;
    }
}
class Language {
    [string]$AssetDomain;
    [string]$LangCode;
    [LangType]$LangType;
    [string]$Content;

    Language([string]$assetDoamin, [string]$langCode, [LangType]$langType, [string]$content) {
        $this.AssetDomain = $assetDoamin;
        $this.LangCode = $langCode;
        $this.LangType = $langType;
        $this.Content = $content;
    }
    
    Language([string]$assetPath, [string]$content) {
        $this.AssetDomain = [Language]::GetAssetDomain($assetPath);
        $this.LangCode = [Language]::GetAssetDomain($assetPath);
        $this.LangType = [LangType]::new([io.Path]::GetExtension($assetPath));
        $this.Content = $content;
    }

    Language([IO.FileInfo]$fileInfo){
        $this = [LangType]::new($fileInfo.FullName,$fileInfo.OpenText().ReadToEnd())
    }

    hidden static [string]GetLangCode([string]$assetPath) {
        $regex = [regex]"(?<=lang(\\|/))(.*)(?=.(lang|json))";
        return $regex.Matches($assetPath)[0];
    }
    hidden static [string]GetAssetDomain([string]$assetPath) {
        $regex = [regex]"(?<=(assets(/|\\)))(.*)(?=(/|\\)lang)";
        return $regex.Matches($assetPath)[0];
    }
    [string]GetAssetPath(){

    }
}


$configPath = Join-Path $PWD.Path "config.json";
$tempPath = Join-Path $PWD.Path "tmp";
$projectPath = Join-Path $PWD.Path "project";
$modJarsPath = Join-Path $tempPath "modJars";
$modsExtractedPath = Join-Path $tempPath "extracted";
$tempProjectPath = Join-Path $tempPath "project"
$config = Get-Content $configPath -Raw | ConvertFrom-Json;
$config.key_blacklist = $config.key_blacklist+=$config.vanilla_key_list;

Remove-Item -Path $tempPath -Recurse -Force -ErrorAction Ignore;
New-Item -ItemType Directory -Path $modJarsPath -Force -InformationAction Ignore;
New-Item -ItemType Directory -Path $modsExtractedPath -Force -InformationAction Ignore;
New-Item -ItemType Directory -Path $tempProjectPath -Force -InformationAction Ignore;
