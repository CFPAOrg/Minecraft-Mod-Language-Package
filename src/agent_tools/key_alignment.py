"""
键对齐工具：比较 en_us.json 和 zh_cn.json 的键，输出对齐报告。
用于 translation-reviewer agent 的 Phase 1。

用法:
    python key_alignment.py --en path/to/en_us.json --zh path/to/zh_cn.json [--output path/to/alignment.json]

输出:
    JSON: {
        "matched_entries": [
            {"key": "key1", "en": "English text", "zh": "中文文本"},
            ...
        ],
        "missing_zh": [{"key": "key3", "en": "Only in en"}, ...],
        "extra_zh": [{"key": "key4", "zh": "Only in zh"}, ...],
        "suspicious_untranslated": [
            {"key": "key5", "en": "Same Value", "zh": "Same Value", "reason": "值相同（疑似未翻译）"},
            {"key": "key6", "en": "", "zh": "", "reason": "均为空字符串"},
            ...
        ],
        "stats": {
            "matched": N,
            "missing_zh": N,
            "extra_zh": N,
            "suspicious_untranslated": N,
            "total_en": N,
            "total_zh": N
        }
    }
"""
import argparse
import json
import sys
from pathlib import Path


def load_json(path: str) -> dict:
    with open(path, "r", encoding="utf-8") as f:
        return json.load(f)


def align_keys(en_data: dict, zh_data: dict) -> dict:
    en_keys = set(en_data.keys())
    zh_keys = set(zh_data.keys())

    common = en_keys & zh_keys
    matched = [
        {"key": k, "en": en_data[k], "zh": zh_data[k]}
        for k in sorted(common)
    ]
    missing_zh = [
        {"key": k, "en": en_data[k]} for k in sorted(en_keys - zh_keys)
    ]
    extra_zh = [
        {"key": k, "zh": zh_data[k]} for k in sorted(zh_keys - en_keys)
    ]

    suspicious = []
    for entry in matched:
        en_val = entry["en"]
        zh_val = entry["zh"]
        if en_val == zh_val:
            if en_val == "":
                reason = "均为空字符串"
            else:
                reason = "值相同（疑似未翻译）"
            suspicious.append({
                "key": entry["key"],
                "en": en_val,
                "zh": zh_val,
                "reason": reason,
            })

    return {
        "matched_entries": matched,
        "missing_zh": missing_zh,
        "extra_zh": extra_zh,
        "suspicious_untranslated": suspicious,
        "stats": {
            "matched": len(matched),
            "missing_zh": len(missing_zh),
            "extra_zh": len(extra_zh),
            "suspicious_untranslated": len(suspicious),
            "total_en": len(en_keys),
            "total_zh": len(zh_keys),
        },
    }


def main() -> None:
    parser = argparse.ArgumentParser(
        description="比较 en_us.json 和 zh_cn.json 的键对齐情况"
    )
    parser.add_argument("--en", required=True, help="en_us.json 路径")
    parser.add_argument("--zh", required=True, help="zh_cn.json 路径")
    parser.add_argument("--output", default=None, help="保存对齐报告到文件（可选）")

    args = parser.parse_args()

    try:
        en_data = load_json(args.en)
        zh_data = load_json(args.zh)
    except FileNotFoundError as e:
        print(json.dumps({"error": f"文件未找到: {e}"}, ensure_ascii=False))
        sys.exit(1)
    except json.JSONDecodeError as e:
        print(json.dumps({"error": f"JSON解析错误: {e}"}, ensure_ascii=False))
        sys.exit(1)

    result = align_keys(en_data, zh_data)

    if args.output:
        output_path = Path(args.output)
        output_path.parent.mkdir(parents=True, exist_ok=True)
        with open(output_path, "w", encoding="utf-8") as f:
            json.dump(result, f, ensure_ascii=False, indent=2)

    print(json.dumps(result, ensure_ascii=False, indent=2))


if __name__ == "__main__":
    main()
