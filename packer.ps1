Add-Type -TypeDefinition @"
using System.Collections;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    public class Properties:IEnumerable<KeyValuePair<string,string>>
    {
        public Properties(StreamReader streamReader)
        {
            Load(streamReader);
        }

        public Properties()
        {
        }

        public string this[string key]
        {
            get => Dictionary[key];
            set => Dictionary[key]=value;
        }

        private static readonly char[] HexDigit =
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'
        };

        public Dictionary<string, string> Dictionary = new Dictionary<string, string>();


        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return Dictionary.GetEnumerator();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var (key, value) in Dictionary) sb.AppendLine(key + "=" + value);
            return sb.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Load(StreamReader reader)
        {
            var lr = new LineReader(reader);
            var convtBuf = new char[1024];
            int limit;

            while ((limit = lr.ReadLine()) >= 0)
            {
                var keyLen = 0;
                var valueStart = limit;
                var hasSep = false;

                var precedingBackslash = false;
                char c;
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
                Dictionary[key] = value;
            }
        }

        /*
         * Converts encoded &#92;uxxxx to unicode chars
         * and changes special saved chars to their original forms
         */
        private string LoadConvert(IReadOnlyList<char> input, int off, int len, char[] convtBuf)
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

                        output[outLen++] = (char) value;
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

        public void Store(StreamWriter writer, string comments)
        {
            Store0(writer, comments, false);
        }

        public void Store(Stream outStream, string comments)
        {
            Store0(new StreamWriter(outStream, Encoding.UTF8), comments, true);
        }

        private void Store0(StreamWriter bw, string comments, bool escUnicode)
        {
            if (comments != null) WriteComments(bw, comments);

            bw.Write("#" + new DateTime().ToString(CultureInfo.InvariantCulture));
            bw.WriteLine();
            //synchronized(this)
            //{
            foreach (var i in Dictionary.Keys)
            {
                var key = i;
                var val = Dictionary[key ?? throw new InvalidOperationException()];
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

        public IEnumerable<string> PropertyNames()
        {
            return Dictionary.Keys;
        }

        private static char ToHex(int nibble)
        {
            return HexDigit[nibble & 0xF];
        }

        private class LineReader
        {
            private readonly char[] _inCharBuf;
            private readonly StreamReader _reader;
            private int _inLimit;
            private int _inOff;
            public char[] LineBuf = new char[1024];

            public LineReader(StreamReader reader)
            {
                _reader = reader;
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
                        _inLimit = _reader.Read(_inCharBuf);
                        _inOff = 0;
                        if (_inLimit <= 0)
                        {
                            if (len == 0 || isCommentLine) return -1;

                            if (precedingBackslash) len--;

                            return len;
                        }
                    }

                    var c = _inCharBuf[_inOff++];

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
                            _inLimit = _reader.Read(_inCharBuf);
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
$configPath = Join-Path $PWD -ChildPath "config.json";
$projectPath = Join-Path $PWD -ChildPath "project";
$outputPath = Join-Path $PWD -ChildPath "output";
$zipArchivePath = Join-Path $PWD -ChildPath "Minecraft-Mod-Language-Modpack.zip";
$vanillaKeyCounter = 0;
$blackListKeyCounter = 0;
$config = Get-Content $configPath -Raw|ConvertFrom-Json;
Remove-Item $outputPath -Recurse -Force -ErrorAction Ignore;
Remove-Item $zipArchivePath -Force -ErrorAction Ignore;
$files = Get-ChildItem $projectPath -Recurse -File | Where-Object { $_.BaseName -ne "en_us" };
foreach ($fi in $files) {
    $dest = (Join-Path $outputPath -ChildPath ([IO.Path]::GetRelativePath($projectPath, $fi.FullName)));
    New-Item -Path ([io.Path]::GetDirectoryName($dest)) -ItemType Directory -InformationAction Ignore -ErrorAction Ignore;
    if ($fi.Extension -eq ".lang") {
        $isEnhanced = $false;
        foreach($line in ($fi | Get-Content)){
            if ([string]::IsNullOrWhiteSpace($line)) {
                continue;
            }
            if ($line.StartsWith("#PARSE_ESCAPES")) {
                $isEnhanced=$true;
                break;
            }
        }
        $p = [Properties]::new();
        if ($isEnhanced -eq $true) {
            $reader = [io.file]::OpenRead($fi.FullName);
            $p.Load($reader);
            $reader.Dispose();
        }
        else {
            foreach($line in ($fi | Get-Content)){
                if ((-not [string]::IsNullOrEmpty($line))-and( $line[0] -ne "#")) {
                    $a = $line -split "=", 2;
                    $p[$a[0]] = $a[1];
                }
            }
        }
        foreach($key in $config.key_blacklist){
            if($p.Dictionary.Remove($key)){
                $blackListKeyCounter++;
            }
        }
        foreach($key in $config.vanilla_key_list){
            if($p.Dictionary.Remove($key)){
                $vanillaKeyCounter++;
            }
        }
        New-Item -ItemType File -Value ($p.ToString()) -Path $dest -InformationAction Ignore -Force; 
    }
    else {
        Copy-Item -Path $fi.FullName  -Destination (Join-Path $outputPath -ChildPath ([IO.Path]::GetRelativePath($projectPath, $fi.FullName)));
    }
}
Compress-Archive "$outputPath/*" $zipArchivePath -CompressionLevel Optimal;
"本次打包删除了$($vanillaKeyCounter)个原版key和$($blackListKeyCounter)个黑名单中的key"