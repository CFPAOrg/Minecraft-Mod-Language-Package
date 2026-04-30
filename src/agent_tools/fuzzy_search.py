"""
轻量模糊搜索工具：在翻译记忆库中查找与查询字符串最相似的行。
用于 translation-reviewer agent 的翻译记忆匹配。

用法:
    python fuzzy_search.py --query "待翻译文本" --en en_us.json --zh zh_cn.json [--threshold 50] [--top 5]

输出:
    JSON: { "similar_lines": [{ "similarity": 85.5, "key": "...", "en": "...", "zh": "..." }, ...] }
"""
import argparse
import json
import sys
from typing import Any


def levenshtein_distance(s1: str, s2: str) -> int:
    """计算编辑距离（纯Python，无依赖）"""
    if len(s1) < len(s2):
        return levenshtein_distance(s2, s1)
    if len(s2) == 0:
        return len(s1)
    previous_row = range(len(s2) + 1)
    for i, c1 in enumerate(s1):
        current_row = [i + 1]
        for j, c2 in enumerate(s2):
            insertions = previous_row[j + 1] + 1
            deletions = current_row[j] + 1
            substitutions = previous_row[j] + (c1 != c2)
            current_row.append(min(insertions, deletions, substitutions))
        previous_row = current_row
    return previous_row[-1]


def calc_similarity(query: str, line: str) -> float:
    """计算相似度 0~100"""
    if not query or not line:
        return 0.0
    dist = levenshtein_distance(query, line)
    max_len = max(len(query), len(line))
    return round(100 * (1 - dist / max_len), 2)


def fuzzy_search_lines(
    query: str,
    en_entries: dict[str, str],
    zh_entries: dict[str, str],
    top_n: int = 5,
    threshold: float = 50.0,
) -> list[dict[str, Any]]:
    """
    在翻译记忆库中模糊搜索

    :param query: 待查找的英文原文
    :param en_entries: 翻译记忆库英文条目 {key: english_text}
    :param zh_entries: 对应中文翻译 {key: chinese_text}
    :param top_n: 返回最相似的N条
    :param threshold: 相似度阈值（低于则过滤）
    :return: [{"similarity": 分值, "key": 键名, "en": 英文, "zh": 中文}, ...]
    """
    results: list[dict[str, Any]] = []
    for key, en_text in en_entries.items():
        sim = calc_similarity(query, en_text)
        if sim >= threshold:
            results.append({
                "similarity": sim,
                "key": key,
                "en": en_text,
                "zh": zh_entries.get(key, "(无翻译)"),
            })
    results.sort(key=lambda x: x["similarity"], reverse=True)
    return results[:top_n]


def load_json(path: str) -> dict:
    """加载JSON文件"""
    with open(path, "r", encoding="utf-8") as f:
        return json.load(f)


def main() -> None:
    parser = argparse.ArgumentParser(
        description="在翻译记忆库中模糊搜索相似翻译"
    )
    parser.add_argument("--query", required=True, help="待查找的英文原文")
    parser.add_argument("--en", required=True, help="en_us.json 路径")
    parser.add_argument("--zh", required=True, help="zh_cn.json 路径")
    parser.add_argument(
        "--threshold", type=float, default=50.0, help="相似度阈值 (0-100)，默认50"
    )
    parser.add_argument(
        "--top", type=int, default=5, help="返回最相似的前N条，默认5"
    )

    args = parser.parse_args()

    try:
        en_entries = load_json(args.en)
        zh_entries = load_json(args.zh)
    except FileNotFoundError as e:
        print(json.dumps({"error": f"文件未找到: {e}"}, ensure_ascii=False))
        sys.exit(1)
    except json.JSONDecodeError as e:
        print(json.dumps({"error": f"JSON解析错误: {e}"}, ensure_ascii=False))
        sys.exit(1)

    matches = fuzzy_search_lines(
        query=args.query,
        en_entries=en_entries,
        zh_entries=zh_entries,
        top_n=args.top,
        threshold=args.threshold,
    )

    output = {"similar_lines": matches}
    print(json.dumps(output, ensure_ascii=False, indent=2))


if __name__ == "__main__":
    main()
