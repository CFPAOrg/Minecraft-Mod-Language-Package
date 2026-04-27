### 总概

```mermaid
flowchart LR
    1.21.1 -->|indirect| 1.21.1-fabric
    1.20.1 -->|indirect| 1.20.1-fabric
    1.21.1 -->|indirect| 1.19.2/1.19.2-fabric & 1.18.2
    1.18.2 -->|indirect| 1.18.2-fabric & 1.16.5
    1.18.2 -->|composition| 1.18.2-fabric & 1.16.5
    1.21.1 -->|indirect| 1.20.1
    linkStyle 6,7 color:royalblue,stroke:royalblue
```

```
1.21.1
 ├── 1.21.1-fabric
 ├── 1.20.1
 │    └── 1.20.1-fabric
 ├── 1.19.2/1.19.2-fabric
 └── 1.18.2 (composition)
      ├── 1.18.2-fabric
      └── 1.16.5
```

### 链接区域

- [1.16.5](/projects/assets/macaws-paths-and-pavings/1.16/mcwpaths)
- [1.18.2](/projects/assets/macaws-paths-and-pavings/1.18/mcwpaths)
- [1.19.2](/projects/assets/macaws-paths-and-pavings/1.19/mcwpaths)
- [1.20.1](/projects/assets/macaws-paths-and-pavings/1.20/mcwpaths)
- [1.21.1](/projects/assets/macaws-paths-and-pavings/1.21/mcwpaths)
- [1.18.2-fabric](/projects/assets/macaws-paths-and-pavings/1.18-fabric/mcwpaths)
- [1.20.1-fabric](/projects/assets/macaws-paths-and-pavings/1.20-fabric/mcwpaths)
- [1.21.1-fabric](/projects/assets/macaws-paths-and-pavings/1.21-fabric/mcwpaths)