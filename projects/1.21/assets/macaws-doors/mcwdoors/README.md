### 总概

```mermaid
flowchart LR
    1.21.1 -->|indirect| 1.21.1-fabric
    1.20.1 -->|indirect| 1.20.1-fabric
    1.19.2/1.19.2-fabric
    1.18.2 -->|indirect| 1.18.2-fabric
    1.21.1 -->|indirect| 1.20.1 & 1.19.2/1.19.2-fabric & 1.18.2 & 1.16.5
```

```
1.21.1
 ├── 1.21.1-fabric
 ├── 1.20.1
 │    └── 1.20.1-fabric
 ├── 1.19.2/1.19.2-fabric
 ├── 1.18.2
 │    └── 1.18.2-fabric (singleton)
 └── 1.16.5
```

### 链接区域

- [1.16.5](/projects/1.16/assets/macaws-doors/mcwdoors)
- [1.18.2](/projects/1.18/assets/macaws-doors/mcwdoors)
- [1.19.2](/projects/1.19/assets/macaws-doors/mcwdoors)
- [1.20.1](/projects/1.20/assets/macaws-doors/mcwdoors)
- [1.21.1](/projects/1.21/assets/macaws-doors/mcwdoors)
- [1.18.2-fabric](/projects/1.18-fabric/assets/macaws-doors/mcwdoors)
- [1.20.1-fabric](/projects/1.20-fabric/assets/macaws-doors/mcwdoors)
- [1.21.1-fabric](/projects/1.21-fabric/assets/macaws-doors/mcwdoors)