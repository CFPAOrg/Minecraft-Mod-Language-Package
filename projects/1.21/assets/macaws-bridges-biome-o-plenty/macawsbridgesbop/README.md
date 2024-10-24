### 总概

```mermaid
flowchart LR
    1.21.1 -->|indirect| 1.21.1-fabric
    1.20.4 -->|indirect| 1.20.4-fabric
    1.19.2 -->|indirect| 1.18.2 & 1.16.5
    1.21.1 -->|indirect| 1.20.4 & 1.19.2
    1.20.4-fabric -->|composition| 1.19.2
    linkStyle 6 color:royalblue,stroke:royalblue
```

```
1.21.1
 ├── 1.21.1-fabric
 ├── 1.20.4
 │    └── 1.20.4-fabric (composition)
 └── 1.19.2 (composition)
      ├── 1.18.2
      └── 1.16.5
```

### 链接区域

- [1.16.5](/projects/1.16/assets/macaws-bridges-biome-o-plenty/macawsbridgesbop)
- [1.18.2](/projects/1.18/assets/macaws-bridges-biome-o-plenty/macawsbridgesbop)
- [1.19.2](/projects/1.19/assets/macaws-bridges-biome-o-plenty/macawsbridgesbop)
- [1.20.4](/projects/1.20/assets/macaws-bridges-biome-o-plenty/macawsbridgesbop)
- [1.21.1](/projects/1.21/assets/macaws-bridges-biome-o-plenty/macawsbridgesbop)
- [1.20.4-fabric](/projects/1.20-fabric/assets/macaws-bridges-biome-o-plenty/macawsbridgesbop)
- [1.21.1-fabric](/projects/1.21-fabric/assets/macaws-bridges-biome-o-plenty/macawsbridgesbop)