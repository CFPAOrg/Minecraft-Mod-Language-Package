### 总概

```mermaid
flowchart LR
    1.21.1 -->|indirect| 1.21.1-fabric
    1.20.1 -->|indirect| 1.20.1-fabric
    1.21.1 -->|indirect| 1.19.2/1.19.2-fabric & 1.18.2
    1.18.2 -->|indirect| 1.18.2-fabric & 1.16.5
    1.18.2 -->|singleton| 1.18.2-fabric & 1.16.5
    1.18.2 -->|composition| 1.18.2-fabric & 1.16.5
    1.21.1 -->|indirect| 1.20.1
    linkStyle 6,7 color:crimson,stroke:crimson
    linkStyle 8,9 color:royalblue,stroke:royalblue
```

```
1.21.1
 ├── 1.21.1-fabric
 ├── 1.20.1
 │    └── 1.20.1-fabric
 ├── 1.19.2/1.19.2-fabric
 └── 1.18.2 (singleton)(composition)
      ├── 1.18.2-fabric
      └── 1.16.5
```

### 链接区域

- [1.16.5](/projects/assets/macaws-bridges/1.16/mcwbridges)
- [1.18.2](/projects/assets/macaws-bridges/1.18/mcwbridges)
- [1.19.2](/projects/assets/macaws-bridges/1.19/mcwbridges)
- [1.20.1](/projects/assets/macaws-bridges/1.20/mcwbridges)
- [1.21.1](/projects/assets/macaws-bridges/1.21/mcwbridges)
- [1.18.2-fabric](/projects/assets/macaws-bridges/1.18-fabric/mcwbridges)
- [1.20.1-fabric](/projects/assets/macaws-bridges/1.20-fabric/mcwbridges)
- [1.21.1-fabric](/projects/assets/macaws-bridges/1.21-fabric/mcwbridges)