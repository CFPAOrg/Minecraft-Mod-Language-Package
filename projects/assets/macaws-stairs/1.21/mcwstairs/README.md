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

- [1.16.5](/projects/assets/macaws-stairs/1.16/mcwstairs)
- [1.18.2](/projects/assets/macaws-stairs/1.18/mcwstairs)
- [1.19.2](/projects/assets/macaws-stairs/1.19/mcwstairs)
- [1.20.1](/projects/assets/macaws-stairs/1.20/mcwstairs)
- [1.21.1](/projects/assets/macaws-stairs/1.21/mcwstairs)
- [1.18.2-fabric](/projects/assets/macaws-stairs/1.18-fabric/mcwstairs)
- [1.20.1-fabric](/projects/assets/macaws-stairs/1.20-fabric/mcwstairs)
- [1.21.1-fabric](/projects/assets/macaws-stairs/1.21-fabric/mcwstairs)